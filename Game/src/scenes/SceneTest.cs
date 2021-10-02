using System;
using Raylib_cs;

namespace Game {

    public class SceneTest : Scene {

        public SceneTest(SceneID sceneId) : base(sceneId) {

        }


        public override void Events() {

        }
        public override void Update() {
            
        }
        public override void Render() {

            Raylib.ClearBackground(Color.BLACK);
        }
    }
}