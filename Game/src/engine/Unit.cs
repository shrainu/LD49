using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Unit : Entity
    {
        List<Spell> spells = new();
        public Spell this[int i]
        {
            get { return spells[i]; }
            set { spells[i] = value; }
        }

        public Unit(Transform transform, EntityTag tag = EntityTag.ENEMY, string name = "Unit")
            : base(transform, tag, name) { }
    }
}
