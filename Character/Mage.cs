using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character
{
    class Mage : Hero
    {
        public Mage(string Name)
        {
            this.Name = Name;
            this.Class = "Mage";
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
