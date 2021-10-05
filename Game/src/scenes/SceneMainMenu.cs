using System;
using Raylib_cs;

namespace Game {

    public class SceneMainMenu : Scene {

        public SceneMainMenu() : base(SceneID.MAIN) {

        }


        public override void Events() {

        }
        public override void Update() {
            
        }
        public override void Render() {

            // Clean Background
            Raylib.ClearBackground(Color.WHITE);
        }
    }
}