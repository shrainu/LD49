using Raylib_cs;


namespace Game {

    public class Transform {

        // Properties
        public Vector2 position;
        public Vector2 size;
        public float rotation, scale;

        public Transform(Vector2 position, Vector2 size) {

            this.position = position;
            this.size = size;
            rotation = 0.0f;
            scale = 1.0f;
        }
        public Transform(float x, float y, float width, float height) {

            this.position = new Vector2(x, y);
            this.size = new Vector2(width, height);
            rotation = 0.0f;
            scale = 1.0f;
        }

        public override string ToString() {
            return "[ Position : " + position.ToString() + ", Size : " + size.ToString() + " ]";
        }
    }
}