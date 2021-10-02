using System;
using Raylib_cs;

namespace Game {

    public class Tilemap {

        // Properties
        public int width, height, tileSize;
        public Tile[,] tiles;

        // Private Properties
        private Texture2D tileset;


        public Tilemap(int width, int height, int tileSize, string filepath) {

            this.width = width;
            this.height = height;
            this.tileSize = tileSize;

            tiles = new Tile[width, height];

            LoadTileset(filepath);

            // Remove this line in the future to prevent automatic tilecreation
            CreateTiles();
        }


        public void CreateTiles() {

            for (int x = 0; x < width; x++) {

                for (int y = 0; y < height; y++) {

                    tiles[x, y] = new Tile(new Vector2(x, y), tileSize, 0); // Tile index is set to 0 for now
                }
            }
        }


        public void Update() {

            for (int x = 0; x < width; x++) {

                for (int y = 0; y < height; y++) {

                    tiles[x, y].Update();
                }
            }
        }
        public void Render() {

            for (int x = 0; x < width; x++) {

                for (int y = 0; y < height; y++) {

                    tiles[x, y].Render(ref tileset);
                }
            }
        }


        public void ActTileTurns() {
            Console.WriteLine("Called");
            for (int x = 0; x < width; x++) {

                for (int y = 0; y < height; y++) {

                    tiles[x, y].ActTurn();
                }
            }
        }


        private void LoadTileset(string filepath) {

            // Load Image to the RAM
            Image temp = Raylib.LoadImage(filepath);
            // Create a texture from Image data which is loaded to VRAM
            tileset = Raylib.LoadTextureFromImage(temp);
            // Unload the image from RAM
            Raylib.UnloadImage(temp);
        }
    }
}