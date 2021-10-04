using System;
using Raylib_cs;

namespace Game {

    public class SceneTest : Scene {

        // Turn Manager
        TurnManager turnManager;

        // Entity Manager
        EntityManager entityManager;

        // Tilemap
        Tilemap tilemap;

        // Camera
        Camera2D camera2D;

        // Player
        Player player;


        public SceneTest(SceneID sceneId) : base(sceneId) {

            // Initialize Tilemap
            tilemap = new Tilemap(40, 40, 16, "res/tileset_back.png", "res/tileset_front.png");
            tilemap.GenerateNewMap(12, new Vector2int(4, 4), new Vector2int(8, 8));

            // Initialize Entity Manager
            entityManager = new EntityManager();

            // Initialize Turn Manager
            turnManager = new TurnManager(tilemap, entityManager);

            // Setup Camera
            camera2D = new Camera2D(new Vector2(400, 240).ToNumerics(), new Vector2(0, 0).ToNumerics(), 0.0f, 0.75f) ;

            // Create and add entities to the Entity Manager
            player = new Player(new Transform(0, 0, 16, 16), turnManager);
            entityManager.AddEntity(player);
        }


        public override void Events() {

            // Entity Events
            entityManager.Events();

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_R)) {
                tilemap.GenerateNewMap(12, new Vector2int(4, 4), new Vector2int(8, 8));
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
            
            // Render Tilemap
            tilemap.Render();

            // Render Entities
            entityManager.Render();

            // End 2D Mode
            Raylib.EndMode2D();
        }
    }
}