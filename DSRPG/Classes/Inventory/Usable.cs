using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes
{
    class Usable : Item
    {
        public Usable(string name, string image) : base(name, image)
        {
            type = ItemType.Other;
        }
    }
}
