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
        public int IntRequire 
        {
            get { return intRequire; }
        }
        public Spell(string name,int cost, int intRequire,string image, int count = 0) : base(name, image, count)
        {
            this.cost = cost;
            this.intRequire = intRequire;
            type = ItemType.Spell;
        }
        
    }
}
