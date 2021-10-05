using Raylib_cs;

namespace Game {

    public class DungeonMap {

        // Properties
        Vector2 position;
        private readonly int width, height, tileSize;

        // Data
        public int[,] dungeonData;
        Player player = null;
        
        public DungeonMap(int width, int height, int tileSize, Vector2 position = null) {
            
            this.width  = width;
            this.height = height;
            this.tileSize = tileSize;

            dungeonData = new int[width, height];

            if (position == null)
                this.position = new Vector2(Game.displayWidth - (width * tileSize), 0);
            else 
                this.position = position;
        }

        public void UpdateDungeonData() {
            dungeonData = DungeonGenerator.s_DungeonData;
        }

        public void SetPlayer(Player player) {
            this.player = player;
            this.position.y += (int)player.transform.size.y / 2 + 1;
            this.position.x += (int)player.transform.size.x / 2;
        }

        public void Render(ObjectLayer obj, Camera2D camera) {

            // Calculate the camera offset
            Vector2int cameraOffset = new Vector2int((int)camera.offset.X - (int)player.transform.position.x,
                                                     (int)camera.offset.Y - (int)player.transform.position.y);

            // Draw A BackGround
            Raylib.DrawRectangle((int)position.x - cameraOffset.x, (int)position.y - cameraOffset.y, (width * tileSize), (width * tileSize), new Color(0, 99, 0, 122));

            //if (player != null)
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {

                    Vector2int pos = new Vector2int(x * tileSize + (int)position.x - cameraOffset.x, 
                                                    y * tileSize + (int)position.y - cameraOffset.y);

                    if (dungeonData[x, y] == 0) {
                        Raylib.DrawRectangle(pos.x, pos.y, tileSize, tileSize, new Color(0, 191, 0, 159));
                        Raylib.DrawRectangleLinesEx(new Raylib_cs.Rectangle(pos.x, pos.y, tileSize, tileSize), 1, new Color(0, 211, 0, 179));
                    }
                    else if (dungeonData[x, y] > 0) {
                        Raylib.DrawRectangle(pos.x, pos.y, tileSize, tileSize, new Color(0, 56, 0, 179));
                        Raylib.DrawRectangleLinesEx(new Raylib_cs.Rectangle(pos.x, pos.y, tileSize, tileSize), 1, new Color(0, 86, 0, 184));
                    }
                    else {
                        Raylib.DrawRectangleLinesEx(new Raylib_cs.Rectangle(pos.x, pos.y, tileSize, tileSize), 1, new Color(0, 222, 0, 120));
                    }
                }
            }

            // Draw Border
            Raylib.DrawRectangleLines((int)position.x - cameraOffset.x, (int)position.y - cameraOffset.y, (width * tileSize), (width * tileSize), Color.WHITE);

            if (player != null) {
                Vector2int playerPos = obj.GetGridPos(player.transform.position);
                playerPos.x = (playerPos.x * tileSize) + (int)position.x - (int)cameraOffset.x;
                playerPos.y = (playerPos.y * tileSize) + (int)position.y - (int)cameraOffset.y;
                Raylib.DrawRectangle(playerPos.x, playerPos.y, tileSize, tileSize, Color.YELLOW);
            }
        }
    }
}