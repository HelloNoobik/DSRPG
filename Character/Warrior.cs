using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    class Warrior : Hero
    {
        public Warrior(string Name) 
        {
            this.Name = Name;
            this.Class = "Warrior";
            this.Agl = 0;
            this.Str = 0;
            this.Vit = 0;
            this.Sta = 0;
            this.Int = 0;
            this.Hp = 0;
            this.Mana = 0;
            this.Stamina = 0;
        }
    }
}
