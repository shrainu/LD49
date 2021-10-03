using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Game
{
    public class Gene
    {
        public const int Number = 6;
        public const double MaxVal = -1;
        public const double Saturation = 50;
        protected const double _default = 0;

        protected double[] values = new double[Number];
        public double this[int i]
        {
            get { return values[i]; }
            set { values[i] = value; }
        }

        public static bool operator >(Gene gene1, Gene gene2)
        {
            double sum1 = 0;
            double sum2 = 0;
            foreach(double value in gene1.values)
                sum1 += value;
            foreach (double value in gene2.values)
                sum2 += value;
            return (sum1 > sum2);
        }
        public static bool operator <(Gene gene1, Gene gene2)
        {
            double sum1 = 0;
            double sum2 = 0;
            foreach (double value in gene1.values)
                sum1 += value;
            foreach (double value in gene2.values)
                sum2 += value;
            return (sum1 < sum2);
        }

        public Color GetColor()
        {
            const int minDegree = 360 / Number;
            Vector2[] colorVectors = new Vector2[Number];
            
            for (int i = 0; i < Number; i++)
            {
                int hue = minDegree * (i + 1);
                int brightness = (int)(values[i] + MaxVal * (100 / (MaxVal * 2)));
                colorVectors[i].x = (float)Math.Sin(hue) * brightness;
                colorVectors[i].y = (float)Math.Cos(hue) * brightness;
            }

            Vector2 resultColor = new (0, 0);
            
            foreach (Vector2 vector in colorVectors)
            {
                resultColor += vector;
            }

            double resultBrightness = VectorFunctions.Length(resultColor);
            return RayHSV.ColorFromHSV(VectorFunctions.Degree(resultBrightness, resultColor.x), Saturation, resultBrightness);
        }

        public Gene(double[] values)
        {
            int i = 0;
            for (; i < this.values.Length && i < Number; i++)
                this.values[i] = values[i];
            for (; i < Number; i++)
                this.values[i] = _default;
        }
        public Gene()
        {
            for (int i = 0; i < _default; i++)
            {
                values[i] = _default;
            }
        }
        public Gene(Random random)
        {
            for (int i = 0; i < _default; i++)
            {
                values[i] = (double)random.Next(1, 100) / 10;
            }
        }
    }
}
