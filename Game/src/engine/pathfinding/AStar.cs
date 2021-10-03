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
        public AStar(int width, int height, int tileSize) {

        }
    }
}