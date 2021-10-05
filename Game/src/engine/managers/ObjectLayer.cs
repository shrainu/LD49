using System;

namespace Game {

    public class ObjectLayer {

        // Properties
        public readonly int width, height, tileSize;
        public Entity[,] entityArray;

        public ObjectLayer(int width, int height, int tileSize) {

            this.width  = width;
            this.height = height;
            this.tileSize = tileSize;

            entityArray = new Entity[width, height];
        }

        public Entity GetEntity(int x, int y) {

            return entityArray[x, y];
        }

        public void MoveEntity(Entity entity, Vector2int futurePos) {

            Vector2int currentPos = GetGridPos(entity.transform.position);

            entityArray[currentPos.x, currentPos.y] = null;
            entityArray[futurePos.x, futurePos.y]   = entity;
        }

        public Vector2int GetGridPos(Vector2 position) {

            int x = (int)MathF.Floor(position.x / tileSize);
            int y = (int)MathF.Floor(position.y / tileSize);

            return new Vector2int(x, y);
        }

        public Vector2 GetWorldPos(Vector2int position) {
            float x = position.x * 16;
            float y = position.y * 16;

            return new Vector2(x, y);
        }
    }
}