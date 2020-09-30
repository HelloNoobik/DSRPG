using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes
{
    class Spell : Item
    {
        private int cost;
        private int intRequire;
        public int Cost
        {
            get { return cost; }
        }
        public Spell(string name,int cost,string image, int count = 0) : base(name, image, count)
        {
            this.cost = cost;
            type = ItemType.Spell;
        }
        
    }
}
