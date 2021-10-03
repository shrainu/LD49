using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime; //look! a new library!

namespace Game
{
    public class Gene
    {
        public const int Number = 6;
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
        public Gene(Random random) //oh no...
        {
            for (int i = 0; i < _default; i++)
            {
                values[i] = (double)random.Next(1, 100) / 10;
            }
        }
    }
}
