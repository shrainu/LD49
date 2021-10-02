
namespace Game {

    public abstract class Node {

        // Properties
        public Rectangle rect;
        public bool active, render;
        public Node parent = null;

        public Node(Rectangle rect) {

            this.rect = rect;
        }

        public abstract void Events();
        public abstract void Update();
        public abstract void Render();
    }
}