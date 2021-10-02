
namespace Game {

    public class Rectangle {

        // Properties
        public Vector2 position;
        public float width, height;

        public Rectangle(Vector2 position, float height, float width) {

            this.position = position;
            this.width  = width;
            this.height = height;
        }
    }
}