using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDll;

namespace Character
{
    abstract public class Hero
    {
        protected string Name { get; private protected set; }
        protected string Class { get; private protected set; }
        protected int Str { get; private protected set; }
        protected int Agl { get; private protected set; }
        protected int Vit { get; private protected set; }
        protected int Sta { get; private protected set; }
        protected int Int { get; private protected set; }
        protected int Hp { get; private protected set; }
        protected int Mana { get; private protected set; }
        protected int Stamina { get; private protected set; }

        protected Inventory Inventory = new Inventory();

        protected bool IsAlive() 
        {
            return (Hp >= 0 ? true : false);
        }

    }
}
