using Raylib_cs;
using System.Collections.Generic;
using System;

namespace Game {

    public class Player : Unit {

        // Properties

        // References
        TurnManager tm;
        AnimationManager animation = AnimationManager.Instance();

        public Player(Transform transform, TurnManager tm) : base(transform, EntityTag.PLAYER, "Player") {

            // Load base sprites
            SetSprite("res/example.png");

            // Initialize properties
            this.tm = tm;
        }


        public override void Events() {

            GetInput();   
        }
        public override void Update() {
            
            transform.rotation += 1 * Utils.deltaTime;
        }
        public override void Render() {
            
            RGBShader.Instance.SetColorR(Color.DARKGRAY);
            RGBShader.Instance.SetColorG(Color.PURPLE);
            Raylib.DrawText(transform.position.ToString(), 16, 16, 2, Color.WHITE);
            
            Raylib.DrawTextureEx(sprite, transform.position.ToNumerics(), transform.rotation, transform.scale, Color.WHITE);
        }

        // Private Functions
        private void GetInput() {

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) {
                Move(-50, 0);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) {
                Move(50, 0);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) {
                Move(0, -50);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) {
                Move(0, 50);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)) {
                animation.AddAnimation(new Animation(
                    new List<Keyframe>{
                        new Move(8, transform.position, new Vector2(0.1f, 0.1f))
                    }
                    , this
                ));
              
            }
        }

        private void Move(int x, int y ) {
            transform.position.x += x *Utils.deltaTime;
            transform.position.y += y *Utils.deltaTime;
            tm.EndTurn();
        }
    }
}