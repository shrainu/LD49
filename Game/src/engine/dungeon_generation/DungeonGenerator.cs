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

            // Create the n number of rooms
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

            // Set the dungeon data to -1 for each tile
            for (int x = 0; x < width; x++){
                for (int y = 0; y < height; y++){
                    dungeonData[x,y] = -1;
                }
            }

            // Create the Tile indexes
            for (int i = 0; i < rooms.Count; i++) {

                Room t = rooms[i];
                for (int x = t.position.x; x < t.position.x + t.width; x++) {
                    for (int y = t.position.y; y < t.position.y + t.height; y++) {
                        
                        if (x == t.position.x || x == t.position.x + t.width - 1) dungeonData[x, y] = 1;
                        else if (y == t.position.y || y == t.position.y + t.height - 1) dungeonData[x, y] = 1;
                        else dungeonData[x, y] = 0;
                    }
                }
            }

            // Temporary AStar data
            bool[,] tempData = new bool[width, height];
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    tempData[x, y] = true;
                }
            }

            // Create a temporary A* to connect rooms
            AStar tempAStar = new AStar(width, height, 16);
            tempAStar.SetData(tempData);
            // To make sure that corridors are straight
            tempAStar.SetCost(10, 10000);

            for (int i = 0; i < rooms.Count; i++) {

                if (i != rooms.Count - 1) {

                    Vector2int currentRoomCenter = new Vector2int((int)Math.Floor(rooms[i].position.x + rooms[i].width / 2.0f), (int)Math.Floor(rooms[i].position.y + rooms[i].height / 2.0f));
                    Vector2int nextRoomCenter = new Vector2int((int)Math.Floor(rooms[i + 1].position.x + rooms[i + 1].width / 2.0f), (int)Math.Floor(rooms[i + 1].position.y + rooms[i + 1].height / 2.0f));
                    Console.WriteLine("Room Center : {0}, N.Room Center : {1}", currentRoomCenter, nextRoomCenter);
                    List<Vector2int> path = tempAStar.FindPath(currentRoomCenter, nextRoomCenter);
                    if (path == null) Console.WriteLine("Path is null");

                    if (path != null) {
                        for (int j = 0; j < path.Count; j++) 
                            dungeonData[path[j].x, path[j].y] = 0;
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