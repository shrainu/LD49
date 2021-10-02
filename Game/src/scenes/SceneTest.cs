using System;
using Raylib_cs;

namespace Game {

    public class SceneTest : Scene {

        // Entity Manager
        EntityManager entityManager;

        // Tilemap
        Tilemap tilemap;

        public SceneTest(SceneID sceneId) : base(sceneId) {

            // Initialize Tilemap
            tilemap = new Tilemap(16, 16, 16, "res/test_tileset.png");

            // Initialize Entity Manager
            entityManager = new EntityManager();

            // Create and add entities to the Entity Manager
            EntityTest t = new EntityTest(new Transform(100, 100, 50, 50), new Color(123, 50, 255, 255));
            t.SetSprite("res/example.png");
            entityManager.AddEntity(t);
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

            Raylib.ClearBackground(Color.BLACK);

            // Render Tilemap
            tilemap.Render();

            // Render Entities
            entityManager.Render();
        }
    }
}