using Raylib_cs;


namespace Game {

    public class Player : Entity {

        // Properties

        // References
        TurnManager tm;


        public Player(Transform transform, TurnManager tm) : base(transform, EntityTag.PLAYER, "Player") {

            // Load base sprites
            SetSprite("res/player_base_back.png", "res/player_base_front.png");

            // Initialize properties
            this.tm = tm;
        }


        public override void Events() {

            GetInput();   
        }
        public override void Update() {
            
        }
        public override void Render() {
            
            Raylib.DrawTextureEx(spriteBack, transform.position.ToNumerics(), transform.rotation, transform.scale, Color.PURPLE);
            Raylib.DrawTextureEx(spriteFront, transform.position.ToNumerics(), transform.rotation, transform.scale, Color.WHITE);
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
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
                
                tm.EndTurn();
            }
        }

        private void Move(int x, int y ) {
            transform.position.x += x * Utils.deltaTime;
            transform.position.y += y * Utils.deltaTime;
            tm.EndTurn();
        }
    }
}