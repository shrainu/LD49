

namespace Game {

    public class Vector2
    {
        public float x, y;

        public Vector2(float x, float y) { this.x = x; this.y = y; }

        public static Vector2 operator+(Vector2 vec1, Vector2 vec2) {
            return new Vector2(vec1.x + vec2.x, vec1.y + vec2.y);
        }
        public static Vector2 operator-(Vector2 vec1, Vector2 vec2) {
            return new Vector2(vec1.x - vec2.x, vec1.y - vec2.y);
        }
        public static Vector2 operator*(Vector2 vec1, Vector2 vec2) {
            return new Vector2(vec1.x * vec2.x, vec1.y * vec2.y);
        }
        public static Vector2 operator/(Vector2 vec1, Vector2 vec2) {
            return new Vector2(vec1.x / vec2.x, vec1.y / vec2.y);
        }

        public override string ToString() {
            return "( " + x + ", " + y + " )";
        }
    }

    public class Vector3
    {
        public float x, y, z;

        public Vector3(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }

        public static Vector3 operator+(Vector3 vec1, Vector3 vec2) {
            return new Vector3(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z);
        }
        public static Vector3 operator-(Vector3 vec1, Vector3 vec2) {
            return new Vector3(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z - vec2.z);
        }
        public static Vector3 operator*(Vector3 vec1, Vector3 vec2) {
            return new Vector3(vec1.x * vec2.x, vec1.y * vec2.y, vec1.z * vec2.z);
        }
        public static Vector3 operator/(Vector3 vec1, Vector3 vec2) {
            return new Vector3(vec1.x / vec2.x, vec1.y / vec2.y, vec1.z / vec2.z);
        }

        public override string ToString() {
            return "( " + x + ", " + y + ", " + z + " )";
        }
    }
}