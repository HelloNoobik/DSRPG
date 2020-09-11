using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Enums;

namespace Inventory.Classes
{
    class Armor : Item
    {
        public int Defence { get; private set; }
        public ArmorsType Type { get; private set; }
        public Armor(string Title, string Desc, int Defence, string Weight, ArmorsType Type) : base(Title, Desc, Weight)
        {
            this.Defence = Defence;
            ItemType = ItemsType.Weapon;
            this.Type = Type;
        }
    }
}
