using Raylib_cs;

namespace Game {

    public class Tile {

        // Properties
        Vector2 position;
        int tileSize;
        int tileIndex;

        public Tile(Vector2 position, int tileSize, int tileIndex) {

            this.position = position;
            this.tileSize = tileSize;
            this.tileIndex = tileIndex;
        }

        public void Update() {

        }
        public void Render(ref Texture2D tileset) {
            
            RGBShader.Instance.SetColorR(Color.DARKBLUE);
            RGBShader.Instance.SetColorG(new Color(75, 75, 75, 255));
            Raylib.DrawTextureRec(tileset, new Raylib_cs.Rectangle(32, 0, tileSize, tileSize), new System.Numerics.Vector2(position.x * tileSize, position.y * tileSize), Color.WHITE);
        }

        public virtual void ActTurn() {}
    }
}