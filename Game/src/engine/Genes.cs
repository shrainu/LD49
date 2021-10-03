using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Game
{
    public partial class Gene
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
