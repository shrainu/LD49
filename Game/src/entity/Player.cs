using System;
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


        public void SendToStartRoom(Vector2int roomCenter) {

            objectLayer.MoveEntity(this, roomCenter);
            transform.position.x = MathF.Floor(roomCenter.x * transform.size.x);
            transform.position.y = MathF.Floor(roomCenter.y * transform.size.y);
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
                TakeAction(new Vector2int(-1, 0));
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_D)) {
                TakeAction(new Vector2int(+1, 0));
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_W)) {
                TakeAction(new Vector2int(0, -1));
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_S)) {
                TakeAction(new Vector2int(0, +1));
            }
        }

        private void TakeAction(Vector2int action) {

            // Convert current position to grid position
            Vector2int gridPos = objectLayer.GetGridPos(transform.position);
            // Calculate the future position
            Vector2int futurePos = new Vector2int(gridPos.x + action.x, gridPos.y + action.y);

            // Check if player is trying to move out of the map
            if ((futurePos.x >= objectLayer.width  || futurePos.x < 0) ||
                (futurePos.y >= objectLayer.height || futurePos.y < 0))
                return;

            // Check if that position is a wall
            bool isWall = aStarGrid.CheckWalkableTile(futurePos.x, futurePos.y);
            if (isWall) return;

            // If its not a wall check if its occupied
            Entity e = objectLayer.GetEntity(futurePos.x, futurePos.y);

            // If there is no entity move there
            if (e == null) {
                
                objectLayer.MoveEntity(this, futurePos);
                TileMove(action.x, action.y);
            }
            else {
                return; // TODO : Attack that entity here
            }

            turnManager.EndTurn();
        }

        private void TileMove(int x, int y ) {
            transform.position.x += x * 16;
            transform.position.y += y * 16;
        }
    }
}