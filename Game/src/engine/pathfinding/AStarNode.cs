
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

            neighbourNodes = new AStarNode[8]; // Don't change the value one neighbour for each side

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

        public void SetNeighbourNodes() {

            // TODO: Implement this. Remind me to implement this -shrain
        }

        public void CalculateFCost() {
            fCost = gCost + hCost;
        }
    }
}