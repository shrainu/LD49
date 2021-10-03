using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum SpellTag
    {
        ACTIVE,
        PASSIVE
    }

    public abstract class Perk
    {
        public SpellTag Tag { private set; get; }

        protected Gene genes;
        protected Unit owner;
        protected int range;

        public double this[int i]
        {
            get { return genes[i]; }
            set { genes[i] = value; }
        }

        public Perk(Gene genes) {
            this.genes = genes;
            Tag = SpellTag.ACTIVE;
        }

        bool RangeCheck(int x, int y)
        {
            return (x ^ 2 + y ^ 2) < (range ^ 2);
        }
        //protected abstract void Influence(Unit influenced); Replace accordingly
        protected abstract Unit UseGeneral(Tilemap tilemap, int x, int y);
        public void Use(Tilemap tilemap, int x, int y)
        {
            if (RangeCheck(x, y))
                UseGeneral(tilemap, x, y);
        }
    }
}
