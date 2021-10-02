using Raylib_cs;


namespace Game {

    public class Player : Entity {

        // Properties

        // References
        TurnManager tm;


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
            
        }
        public override void Render() {
            
            RGBShader.Instance.SetColorR(Color.GRAY);
            RGBShader.Instance.SetColorG(Color.PURPLE);

            RGBShader.Instance.Bind();
            Raylib.DrawTexture(sprite, (int)transform.position.x, (int)transform.position.y, Color.WHITE);
            RGBShader.Instance.Unbind();
        }

        // Private Functions
        private void GetInput() {

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) {
                Move(-30, 0);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) {
                Move(30, 0);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) {
                Move(0, -30);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) {
                Move(0, 30);
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
                
                tm.ActEnemyTurns();
            }
        }

        private void Move(int x, int y ) {
            transform.position.x += x;
            transform.position.y += y;
            tm.ActEnemyTurns();
        }
    }
}