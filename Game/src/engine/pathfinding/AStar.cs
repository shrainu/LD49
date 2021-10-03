using System;
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
            
            AStarNode startNode = grid.GetNodeByGridPos(startPos.x, startPos.y);
            AStarNode endNode = grid.GetNodeByGridPos(endPos.x, endPos.y);

            return TryFindPath(startNode, endNode);
        }

        public List<Vector2int> FindPath(int startX, int startY, int endX, int endY) {
            
            AStarNode starNode = grid.GetNodeByGridPos(startX, startY);
            AStarNode endNode = grid.GetNodeByGridPos(endX, endY);

            return TryFindPath(starNode, endNode);
        }

        public List<Vector2int> FindPath(AStarNode startNode, AStarNode endNode) {
            
            return TryFindPath(startNode, endNode);
        }


        private List<Vector2int> TryFindPath(AStarNode startNode, AStarNode endNode) {

            PrepareNodes();

            openNodes = new List<AStarNode>();
            closedNodes = new List<AStarNode>();

            // Prepare start node
            startNode.gCost = 0;
            startNode.hCost = CalculateDistance(startNode, endNode);
            startNode.CalculateFCost();

            while (openNodes.Count > 0) {

                AStarNode currentNode = GetBestNode();
                if (currentNode == endNode) {
                    return CalculatePath(endNode);
                }

                openNodes.Remove(currentNode);
                closedNodes.Add(currentNode);

                foreach (AStarNode neighbourNode in currentNode.neighbourNodes) {
                    if (neighbourNode == null || closedNodes.Contains(neighbourNode)) continue;
                    if (!neighbourNode.isWalkable) {
                        closedNodes.Add(neighbourNode);
                        continue; 
                    }

                    int tentativeGCost = currentNode.gCost + CalculateDistance(currentNode, neighbourNode);
                    if (tentativeGCost < neighbourNode.gCost) {

                        neighbourNode.parentNode = currentNode;
                        neighbourNode.gCost = tentativeGCost;
                        neighbourNode.hCost = CalculateDistance(neighbourNode, endNode);
                        neighbourNode.CalculateFCost();

                        if (!openNodes.Contains(neighbourNode)) 
                            openNodes.Add(neighbourNode);
                    }
                }
            }

            // Couldn't find a path return null
            return null;
        }

        private List<Vector2int> CalculatePath(AStarNode endNode) {
            List<Vector2int> path = new List<Vector2int>();

            AStarNode currentNode = endNode;
            path.Add(new Vector2int(currentNode.x, currentNode.y));

            while(currentNode.parentNode != null) {

                currentNode = currentNode.parentNode;
                path.Add(new Vector2int(currentNode.x, currentNode.y));
            }

            path.Reverse();
            return path;
        }

        private int CalculateDistance(AStarNode a, AStarNode b) {

            int xDistance = Math.Abs(a.x - b.x);
            int yDistance = Math.Abs(a.y - b.y);
            int remaining = Math.Abs(xDistance - yDistance);
            return DIAGONAL_MOVE_COST * Math.Min(xDistance, yDistance) + STRAIGHT_MOVE_COST * remaining;
        }

        private AStarNode GetBestNode() {

            int index = 0;
            for (int i = 0; i < openNodes.Count; i++) {
                if (openNodes[i].fCost < openNodes[index].fCost) index = i;
            }
            return openNodes[index];
        }

        private void PrepareNodes() {

            for (int x = 0; x < grid.width; x++) {
                for (int y = 0; y < grid.height; y++) {

                    grid.nodes[x, y].PrepareNode();
                }
            }
        }
    }
}