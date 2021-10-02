using Raylib_cs;


namespace Game {

    public class Player : Entity {

        // Properties

        public Player(Transform transform) : base(transform, EntityTag.PLAYER, "Player") {

            SetSprite("res/example.png");
        }


        public override void Events() {
            
        }
        public override void Update() {
            
            GetMovementInput();
        }
        public override void Render() {
            
            RGBShader.Instance.SetColorR(Color.GRAY);
            RGBShader.Instance.SetColorG(Color.PURPLE);

            RGBShader.Instance.Bind();
            Raylib.DrawTexture(sprite, (int)transform.position.x, (int)transform.position.y, Color.WHITE);
            RGBShader.Instance.Unbind();
        }


        // Private Functions
        private void GetMovementInput() {

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) {
                transform.position.x -= 30;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) {
                transform.position.x += 30;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) {
                transform.position.y -= 30;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) {
                transform.position.y += 30;               
            }
        }
    }
}