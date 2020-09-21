using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes
{
    public enum ItemType
    {
        Item, Armor, Weapon, Spell, Other
    }

    public class Item
    {
        protected string name;
        protected ItemType type;
        protected int count;
        protected string image;

        public delegate void Changed();
        public event Changed ItemChanged;


        public string Image
        {
            get { return image; }
        }
        public string Name
        {
            get { return name; }
        }

        public ItemType Type
        {
            get
            {
                return type;
            }
        }

        public int Count
        {
            get { return count; }
            set
            {
                if (count >= 100) return;
                if (value > 100)
                {
                    count = 100;
                    return;
                }
                count = value;
                ItemChanged?.Invoke();
            }
        }
        public Item(string name, ItemType type, string image, int count = 0)
        {
            this.name = name;
            this.type = type;
            this.image = image;
            Count = count;
        }

        public Item(string name, string image, int count = 0)
        {
            this.name = name;
            this.image = image;
            Count = count;
        }
    }
}
