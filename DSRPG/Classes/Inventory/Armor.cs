using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes
{
    class Armor : Item
    {
        private double defence;

        public double Defence
        {
            get 
            {
                return defence;
            }

            set 
            {
                if (value >= 0 && value <= 1) defence = value;
            }
        }

        public Armor(string name, string image, double defence) : base(name, image) 
        {
            type = ItemType.Armor;
            this.defence = defence;
        }
    }
}
