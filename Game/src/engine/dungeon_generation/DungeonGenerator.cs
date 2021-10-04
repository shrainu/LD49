using System;
using System.Collections.Generic;


namespace Game {

    public static class DungeonGenerator { 

        // Room
        struct Room {

            public Vector2int position;
            public int width, height;

            public Room(Vector2int position, int width, int height) {
                this.position = position;
                this.width = width;
                this.height = height;
            }
        }

        // Properties
        private static Random rnd = new Random();
        private static readonly int maxRetryCount = 50;


        public static int[,] GenerateDungeon(int width, int height, int roomCount, Vector2int roomSizeMin, Vector2int roomSizeMax) {

            int[,] dungeonData = new int[width, height];
            List<Room> rooms = new List<Room>();
            int roomCreated = 0;
            int retryCount = 0;

            while (roomCreated < roomCount) {

                Vector2int roomPosition = new Vector2int(rnd.Next(0, width), rnd.Next(0, height));
                int roomWidth  = rnd.Next(roomSizeMin.x, roomSizeMax.x);
                int roomHeight = rnd.Next(roomSizeMin.y, roomSizeMax.y);

                Room temp = new Room(roomPosition, roomWidth, roomHeight);

                bool valid = CheckValidRoom(temp, width, height);
                for (int i = 0; valid && i < rooms.Count; i++) {

                    valid = !CheckRoomCollion(temp, rooms[i]);
                }

                if (valid) {
                    rooms.Add(temp);
                    roomCreated++;
                }
                else {
                    retryCount++;
                    if (retryCount >= maxRetryCount) {
                        retryCount = 0;
                        roomCreated++;
                    }
                }
            }

            for (int x = 0; x < width; x++){
                for (int y = 0; y < height; y++){
                    dungeonData[x,y] = -1;
                }
            }

            for (int i = 0; i < rooms.Count; i++) {

                Room t = rooms[i];
                for (int x = t.position.x; x < t.position.x + t.width; x++) {
                    for (int y = t.position.y; y < t.position.y + t.height; y++) {
                        dungeonData[x, y] = 0;
                    }
                }
            }

            return dungeonData;
        }

        private static bool CheckRoomCollion(Room r1, Room r2) {

            bool collisionX = r1.position.x + r1.width >= r2.position.x &&
                              r2.position.x + r2.width >= r1.position.x;
            bool collisionY = r1.position.y + r1.height >= r2.position.y &&
                              r2.position.y + r2.height >= r1.position.y;

            return collisionX && collisionY;
        }

        private static bool CheckValidRoom(Room r, int width, int height) {

            if (r.position.x + r.width >= width || r.position.y + r.height >= height)
                return false;

            return true;
        }
    }
}