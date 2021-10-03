
namespace Game {

    public class AStarNode{ 

        // Properties
        public readonly int x, y;
        public bool isWalkable;

        // Pathfinding
        public int gCost, hCost, fCost;
        public AStarNode parentNode;
        public AStarNode[] neighbourNodes;


        public AStarNode(int x, int y, bool isWalkable) {

            this.x = x;
            this.y = y;
            this.isWalkable = isWalkable;

            neighbourNodes = new AStarNode[8]; // Don't change the value, one neighbour for each side

            // Prepare Node
            PrepareNode();
        }


        // Prepares node to be used in the next pathfinding sequance
        public void PrepareNode() {

            gCost = int.MaxValue;
            hCost = 0;
            CalculateFCost();

            parentNode = null;
        }

        public void SetNeighbourNodes(AStarNode[,] nodes, int width, int height) {

            bool leftEdge  = (x - 1 >= 0);
            bool rightEdge = (x + 1 <  width);

            if (y - 1 >= 0) {

                // Top N.N (N.N = Neighbour Node)
                neighbourNodes[0] = nodes[x, y - 1];

                // Top Left N.N
                if (leftEdge) neighbourNodes[1] = nodes[x - 1, y - 1];
                // Top Right N.N
                if (rightEdge) neighbourNodes[2] = nodes[x + 1, y - 1];
            }
            if (y + 1 < height) {

                // Bottom N.N
                neighbourNodes[3] = nodes[x, y + 1];

                // Bottom Left N.N
                if (leftEdge) neighbourNodes[4] = nodes[x - 1, y + 1];
                // Bottom Right N.N
                if (rightEdge) neighbourNodes[5] = nodes[x + 1, y + 1];
            }
            // Left N.N
            if (leftEdge) neighbourNodes[6] = nodes[x - 1, y];
            // Right N.N
            if (rightEdge) neighbourNodes[7] = nodes[x + 1, y];
        }

        public void CalculateFCost() {
            fCost = gCost + hCost;
        }
    }
}