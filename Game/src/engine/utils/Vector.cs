

namespace Game {

    public partial class Vector2
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
        public System.Numerics.Vector2 ToNumerics() {
            return new System.Numerics.Vector2(x, y);
        }
    }

    public class Vector2int {

        public int x, y;

        public Vector2int(int x, int y) { this.x = x; this.y = y; }

        public static Vector2int operator+(Vector2int vec1, Vector2int vec2) {
            return new Vector2int(vec1.x + vec2.x, vec1.y + vec2.y);
        }
        public static Vector2int operator-(Vector2int vec1, Vector2int vec2) {
            return new Vector2int(vec1.x - vec2.x, vec1.y - vec2.y);
        }
        public static Vector2int operator*(Vector2int vec1, Vector2int vec2) {
            return new Vector2int(vec1.x * vec2.x, vec1.y * vec2.y);
        }
        public static Vector2int operator/(Vector2int vec1, Vector2int vec2) {
            return new Vector2int(vec1.x / vec2.x, vec1.y / vec2.y);
        }

        public override string ToString() {
            return "( " + x + ", " + y + " )";
        }
        public System.Numerics.Vector2 ToNumerics() {
            return new System.Numerics.Vector2(x, y);
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
          public System.Numerics.Vector3 ToNumerics() {
            return new System.Numerics.Vector3(x, y, z);
        }
    }
}