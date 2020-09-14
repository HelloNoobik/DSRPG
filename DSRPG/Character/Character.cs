using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG
{
    class Character
    {
        public string Name { get; private set; }
        public string Class { get; private set; }
        public string Gender { get; private set; }
        public string Gift { get; private set; }
        public Character(string Name, string Class, string Gender, string Gift) 
        {
            this.Name = Name;
            this.Class = Class;
            this.Gender = Gender;
            this.Gift = Gift;
        }
    }
}
