using Raylib_cs;

namespace Game {

    public class Tile {

        // Properties
        Vector2 position;
        int tileSize;
        public int tileIndex;

        public Tile(Vector2 position, int tileSize, int tileIndex) {

            this.position = position;
            this.tileSize = tileSize;
            this.tileIndex = tileIndex;
        }

        public void Update() {

        }
        public void Render(Texture2D tilesetBack, Texture2D tilesetFront) {
            
            if (tileIndex == 0) {
                Raylib.DrawTextureRec(tilesetBack, new Raylib_cs.Rectangle(0, 16, tileSize, tileSize), new System.Numerics.Vector2(position.x * tileSize, position.y * tileSize), Color.DARKGRAY);
                Raylib.DrawTextureRec(tilesetFront, new Raylib_cs.Rectangle(0, 16, tileSize, tileSize), new System.Numerics.Vector2(position.x * tileSize, position.y * tileSize), Color.DARKBLUE);
            }
            else if (tileIndex == 1) {
                Raylib.DrawTextureRec(tilesetBack, new Raylib_cs.Rectangle(0, 0, tileSize, tileSize), new System.Numerics.Vector2(position.x * tileSize, position.y * tileSize), Color.DARKGRAY);
                Raylib.DrawTextureRec(tilesetFront, new Raylib_cs.Rectangle(0, 0, tileSize, tileSize), new System.Numerics.Vector2(position.x * tileSize, position.y * tileSize), Color.DARKBLUE);
            }
        }

        public virtual void ActTurn() {}
    }
}