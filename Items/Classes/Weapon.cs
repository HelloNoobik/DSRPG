using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Enums;

namespace Inventory.Classes
{
    class Weapon : Item
    {
        public int Damage { get; private set; }
        public WeaponsType Type {get; private set; }
        public Weapon(string Title, string Desc, int Damage, string Weight, WeaponsType Type) : base(Title, Desc, Weight)
        {
            this.Damage = Damage;
            ItemType = ItemsType.Weapon;
            this.Type = Type;
        }
    }
}
