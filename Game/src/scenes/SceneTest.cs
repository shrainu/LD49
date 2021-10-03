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

        public SceneTest(SceneID sceneId) : base(sceneId) {

            // Initialize Tilemap
            tilemap = new Tilemap(16, 16, 16, "res/test_tileset.png");

            // Initialize Entity Manager
            entityManager = new EntityManager();

            // Initialize Turn Manager
            turnManager = new TurnManager(tilemap, entityManager);

            camera2D = new Camera2D(new Vector2(0, 0).ToNumerics(), new Vector2(0, 0).ToNumerics(), 0.0f, 1.0f) ;

            // Create and add entities to the Entity Manager
            Player p = new Player(new Transform(0, 0, 80, 80), turnManager);
            entityManager.AddEntity(p);
        }


        public override void Events() {

            // Entity Events
            entityManager.Events();
        }
        public override void Update() {
            
            // Update Tilemap
            tilemap.Update();

            // Update Entities
            entityManager.Update();
        }
        public override void Render() {

            // Clean Background
            Raylib.ClearBackground(Color.BLACK);
            // Use the RGB shader and begin 2D Mode
            RGBShader.Instance.Bind();
            Raylib.BeginMode2D(camera2D);
            
            // Render Tilemap
            tilemap.Render();

            // Render Entities
            entityManager.Render();

            // Unbind the RGB shader and end 2D Mode
            Raylib.EndMode2D();
            RGBShader.Instance.Unbind();
        }
    }
}