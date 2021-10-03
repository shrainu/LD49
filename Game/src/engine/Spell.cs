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

        public void Use(Tilemap tilemap, int x, int y)
        {
            if ((x ^ 2 + y ^ 2) < (range ^ 2))
                UseGeneral(tilemap, x, y);
        }
        //protected abstract void Influence(Unit influenced); Replace accordingly
        protected abstract Unit UseGeneral(Tilemap tilemap, int x, int y);
    }
}
