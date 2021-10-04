using System;

namespace Game {

    public class AStarGrid {

        // Properties
        public readonly int x, y;
        public readonly int width, height, tileSize;
        public AStarNode[,] nodes;

        public AStarGrid(int width, int height, int tileSize, Vector2int position = null) {

            this.width = width;
            this.height = height;
            this.tileSize = tileSize;

            nodes = new AStarNode[width, height];

            if (position == null) { x = 0; y = 0;}
            else { x = position.x; y = position.y; }

            CreateNodes();
        }


        public void SetData(bool[,] data) {

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {

                    nodes[x, y].isWalkable = data[x, y];
                }
            }
        }

        public void CreateNodes() {

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {

                    // Default value for AStarNodes is isWalkable = true
                    nodes[x,y] = new AStarNode(x, y, true); 
                }
            }

            for (int x = 0; x < width; x++) {
                for(int y = 0; y < height; y++) {

                    nodes[x, y].SetNeighbourNodes(nodes, width, height);
                }
            }
        }

        public AStarNode GetNodeByGridPos(int x, int y) {
            if ((x < 0 || x > width) || (y < 0 || y > height)) return null;
            return nodes[x, y];
        }

        public AStarNode GetNodeByWorldPos(float x, float y) {

            Vector2int gridPos = new Vector2int(((int)x - this.x) / tileSize, ((int)y - this.y) / tileSize);
            if ((gridPos.x < 0 || gridPos.x > width) || (gridPos.y < 0 || gridPos.y > height)) return null;
            return nodes[gridPos.x, gridPos.y];
        }
    }
}