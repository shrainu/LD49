using System;
using Raylib_cs;

namespace Game {

    public class Tilemap {

        // Properties
        public int width, height, tileSize;
        public Tile[,] tiles;

        // Private Properties
        private Texture2D tilesetBack, tilesetFront;


        public Tilemap(int width, int height, int tileSize, string filepathBack, string filepathFront) {

            this.width = width;
            this.height = height;
            this.tileSize = tileSize;

            tiles = new Tile[width, height];

            LoadTileset(filepathBack, filepathFront);
        }


        public void GenerateNewMap(int roomCount, Vector2int minRoomSize, Vector2int maxRoomSize) {

            CreateTiles(DungeonGenerator.GenerateDungeon(width, height, roomCount, minRoomSize, maxRoomSize));
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

                    if (tiles[x, y].tileIndex != -1) tiles[x, y].Render(tilesetBack, tilesetFront);
                }
            }
        }

        public void ActTileTurns() {
            
            for (int x = 0; x < width; x++) {

                for (int y = 0; y < height; y++) {

                    tiles[x, y].ActTurn();
                }
            }
        }


        private void CreateTiles(int[,] data) {

            for (int x = 0; x < width; x++) {

                for (int y = 0; y < height; y++) {

                    tiles[x, y] = new Tile(new Vector2(x, y), tileSize, data[x, y]); // Tile index is set to 0 for now
                }
            }
        }

        private void LoadTileset(string filepathBack, string filepathFront) {

            // Load Image to the RAM
            Image tempBack = Raylib.LoadImage(filepathBack);
            Image tempFront = Raylib.LoadImage(filepathFront);
            // Create a texture from Image data which is loaded to VRAM
            tilesetBack = Raylib.LoadTextureFromImage(tempBack);
            tilesetFront = Raylib.LoadTextureFromImage(tempFront);
            // Unload the image from RAM
            Raylib.UnloadImage(tempBack);
            Raylib.UnloadImage(tempFront);
        }
    }
}