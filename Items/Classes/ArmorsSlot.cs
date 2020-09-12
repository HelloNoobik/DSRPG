using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDll.Enums;

namespace InventoryDll.Classes
{
    public class ArmorsSlot
    {
        public Item Armor { get; private set; }
        private ArmorsType Type { get; set; }
        private ItemsType ItemType = ItemsType.Armor;

        public ArmorsSlot(ArmorsType Type) 
        {
            this.Type = Type;
        }

        public bool Put(Armor Item)
        {
            this.Type = Type;
            if (Item.ItemType == ItemsType.Armor)
            {
                Armor = Item;
                return true;
            }
            return false;
        }
    }
}
