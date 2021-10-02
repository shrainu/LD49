using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Spell
    {
        protected Genes genes;
        protected Unit owner;

        public double this[int i]
        {
            get { return genes[i]; }
            set { genes[i] = value; }
        }

        public Spell(Genes genes) {
            this.genes = genes;
        }

        public void Use(int x, int y)
        {
            Influence(UseGeneral(x, y));
        }
        protected abstract void Influence(Unit influensing);
        protected abstract Unit UseGeneral(int x, int y);
    }
}
