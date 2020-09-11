using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Enums;

namespace Inventory.Classes
{
    class WeaponsSlot
    {
        public Weapon Weapon { get; private set; }
        public ItemsType ItemType = ItemsType.Weapon;

        public void Put(Weapon Weapon) 
        {
            this.Weapon = Weapon;
        }
    }
}
