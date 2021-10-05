using System;
using Raylib_cs;

namespace Game {

    public class SceneDungeon : Scene {

        // Scene Properties
        private const int dungeonWidth  = 40;
        private const int dungeonHeight = 40;
        private const int avarageRoomCount = 12;
        private readonly Vector2int minRoomSize = new Vector2int(8, 8);
        private readonly Vector2int maxRoomSize = new Vector2int(12, 12);
        private const int tileSize = 16;
        private const string defaultTilesetBack  = "res/tileset_back.png";
        private const string defaultTilesetFront = "res/tileset_front.png";

        // System Components
        Camera2D camera2D;
        ObjectLayer objectLayer;
        TurnManager turnManager;
        EntityManager entityManager;
        AnimationManager animationManager;
        Tilemap tilemap;
        AStar aStar;
        // Objects with static storage durations
        Player player;


        public SceneDungeon() : base(SceneID.GAME) {

            // AStar
            aStar = new AStar(dungeonWidth, dungeonHeight, tileSize);

            // Initialize Tilemap
            tilemap = new Tilemap(dungeonWidth, dungeonHeight, tileSize, aStar, defaultTilesetBack, defaultTilesetFront);
            tilemap.GenerateNewMap(avarageRoomCount, minRoomSize, maxRoomSize);

            // Object Layer
            objectLayer = new ObjectLayer(dungeonWidth, dungeonHeight, tileSize);

            // Initialize Entity Manager
            entityManager = new EntityManager();

            // Initialize Animation Manager
            animationManager = AnimationManager.Instance();

            // Initialize Turn Manager
            turnManager = new TurnManager(tilemap, entityManager);

            // Setup Camera
            camera2D = new Camera2D(new Vector2(Game.displayWidth / 2, Game.displayHeight / 2).ToNumerics(), new Vector2(0, 0).ToNumerics(), 0.0f, 1f) ;

            // Create and add entities to the Entity Manager
            player = new Player(new Transform(0, 0, tileSize, tileSize), turnManager, objectLayer, aStar.GetGrid());
            entityManager.AddEntity(player);
        }


        public override void Events() {

            // Entity Events
            entityManager.Events();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_R)) {
                tilemap.GenerateNewMap(avarageRoomCount, minRoomSize, maxRoomSize);
            }
        }
        public override void Update() {
            
            // Update Tilemap
            tilemap.Update();

            // Update Camera Position
            camera2D.target = new System.Numerics.Vector2(player.transform.position.x + player.transform.size.x / 2,
                                                         player.transform.position.y + player.transform.size.y / 2);

            // Update Entities
            entityManager.Update();
        }
        public override void Render() {

            // Clean Background
            Raylib.ClearBackground(Color.BLACK);
            // Begin 2D Mode
            Raylib.BeginMode2D(camera2D);

            // Animate Entities
            animationManager.Animate();
            
            // Render Tilemap
            tilemap.Render();

            // Render Entities
            entityManager.Render();

            // End 2D Mode
            Raylib.EndMode2D();
        }
    }
}