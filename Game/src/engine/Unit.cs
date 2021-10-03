using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Unit : Entity
    {
        protected List<Perk> perks = new();
        public Perk this[int i]
        {
            get { return perks[i]; }
            set { perks[i] = value; }
        }

        public Unit(Transform transform, EntityTag tag = EntityTag.ENEMY, string name = "Unit")
            : base(transform, tag, name) { }
    }
}
