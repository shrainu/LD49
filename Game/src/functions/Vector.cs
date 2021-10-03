using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class VectorFunctions
    {
        public static double Length(Vector2 vector)
        {
            return Math.Sqrt((vector.x * vector.x) + (vector.y * vector.y));
        }
        public static double Degree(Vector2 vector)
        {
            return Math.Asin(Length(vector)/vector.x);
        }
        public static double Degree(double hypotenuse, float adjacent)
        {
            return Math.Asin(hypotenuse / adjacent);
        }
    }
}
