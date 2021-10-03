using System.Collections.Generic;


namespace Game {

    public class AStar {

        // Constans
        private const int STRAIGHT_MOVE_COST = 10;
        private const int DIAGONAL_MOVE_COST = 14;

        // Properties
        public int width, height, tileSize;
        public AStarGrid grid;

        // Pathfinding
        private List<AStarNode> openNodes;
        private List<AStarNode> closedNodes;


        // Constructor
        public AStar(int width, int height, int tileSize, Vector2int position = null) {

            this.width = width;
            this.height = height;
            this.tileSize = tileSize;

            // Setup the AStarGrid we are basically checking if
            // AStar has been created at default position which is 0, 0.
            grid = (position != null) ? new AStarGrid(width, height, tileSize) : new AStarGrid(width, height, tileSize, position);
        }


        public List<Vector2int> FindPath(Vector2int startPos, Vector2int endPos) {
            return null;
        }

        public List<Vector2int> FindPath(int startX, int startY, int endX, int endY) {
            return null;
        }

        public List<Vector2int> FindPath(AStarNode startNode, AStarNode endNode) {
            return null;
        }


        private List<Vector2int> TryFindPath() {

            PrepareNodes();

            return null;
        }

        private void PrepareNodes() {

        }
    }
}