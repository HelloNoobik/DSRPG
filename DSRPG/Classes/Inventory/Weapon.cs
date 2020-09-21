using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes
{
    class Weapon : Item
    {
        private int damage;

        public int Damage 
        {
            get { return damage; }
            set { damage = value; }
        }
        public Weapon(string name, string image, int damage) : base(name,image) 
        {
            type = ItemType.Weapon;

            this.damage = damage;
        }
    }
}
