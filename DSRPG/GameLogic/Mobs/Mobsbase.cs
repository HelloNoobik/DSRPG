using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.GameLogic.Mobs
{
    public abstract class Mobsbase
    {
        protected string name;
        protected int health;
        protected int mana;
        protected int damage;
        protected double armor;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Mana
        {
            get { return mana; }
            set { mana = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public double Armor
        {
            get { return armor; }
            set { armor = value; }
        }

        public override string ToString() //Мож пойже пригодится
        {
            return base.ToString();
        }
    }
}
