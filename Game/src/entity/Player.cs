using Raylib_cs;


namespace Game {

    public class Player : Entity {

        // Properties

        // References
        TurnManager turnManager;
        ObjectLayer objectLayer;
        AStarGrid   aStarGrid;


        public Player(Transform transform, TurnManager tm, ObjectLayer ob, AStarGrid ag) : base(transform, EntityTag.PLAYER, "Player") {

            // Load base sprites
            SetSprite("res/player_base_back.png", "res/player_base_front.png");

            // Initialize References
            turnManager = tm;
            objectLayer = ob;
            aStarGrid   = ag;
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

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_A)) {
                TileMove(-1, 0);
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_D)) {
                TileMove(+1, 0);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_W)) {
                TileMove(0, -1);
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_S)) {
                TileMove(0, +1);
            }
        }

        private void TileMove(int x, int y ) {
            transform.position.x += x * 16;
            transform.position.y += y * 16;
            turnManager.EndTurn();
        }
    }
}