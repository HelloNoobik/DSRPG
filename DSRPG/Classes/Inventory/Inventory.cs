using DSRPG.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using dbItem = DSRPG.Data.Item;
using dbWeapon = DSRPG.Data.Weapon;
using dbSpell = DSRPG.Data.Spell;

namespace DSRPG.Classes
{
    public class Inventory
    {
        private static List<Item> _items = new List<Item>();
        private static Dictionary<string, int> _db = new Dictionary<string, int>();
        private List<Item> items;
        private Dictionary<string, int> db;

        private int[] slots;

        public delegate void Changed();
        public event Changed WeaponChanged;
        public event Changed ArmorChanged;

        public int Weapon
        {
            get
            {
                return slots[5];
            }
            set
            {
                slots[5] = value;
                WeaponChanged?.Invoke();
            }
        }
        public int Armor
        {
            get
            {
                return slots[6];
            }
            set
            {
                slots[6] = value;
                ArmorChanged?.Invoke();
            }
        }
        public int Slot5
        {
            get
            {
                return slots[4];
            }
            set
            {
                slots[4] = value;
            }
        }
        public int Slot4
        {
            get
            {
                return slots[3];
            }
            set
            {
                slots[3] = value;
            }
        }
        public int Slot3
        {
            get
            {
                return slots[2];
            }
            set
            {
                slots[2] = value;
            }
        }
        public int Slot2
        {
            get
            {
                return slots[1];
            }
            set
            {
                slots[1] = value;
            }
        }
        public int Slot1
        {
            get
            {
                return slots[0];
            }
            set
            {
                slots[0] = value;
            }
        }

        public Inventory()
        {
            slots = new int[7] { -1, -1, -1, -1, -1, -1, -1 };
            db = _db;
            items = _items;
        }
        public static void Load()
        {
            using(DSRPGEntities db = new DSRPGEntities()) 
            {
                IQueryable<dbItem> query = db.Item;

                foreach (dbItem item in query) 
                {
                    _db.Add(item.Name, item.Id);

                    if (item.Type == "Оружие")
                    {
                        dbWeapon weapon = db.Weapon.Where(c => c.Id == item.Id).First();
                        _items.Add(new Weapon(weapon.Name,weapon.Image,weapon.Damage));
                    }
                    else if (item.Type == "Заклинание") 
                    {
                        dbSpell spell = db.Spell.Where(c => c.Id == item.Id).First();
                        _items.Add(new Spell(spell.Name, spell.ManaCost, spell.Image));
                    }
                    else 
                    {
                        _items.Add(new Item(item.Name, item.Image));
                    }
                }
            }
        }

        public void AddItem(string item, int count = 1)
        {
            int id = 0;
            if (db.TryGetValue(item, out id))
            {
                items[id].Count += count;
            }
            else
            {
                MessageBox.Show("error");
            }

        }

        public void WeaponUpgrade(Item item)
        {
            items[Weapon] = item;
            Weapon = Weapon;
        }

        public void RemoveItem(string item, int count = 1)
        {
            int id = 0;
            if (db.TryGetValue(item, out id))
            {
                items[id].Count -= count;
            }
            else
            {
                MessageBox.Show("error");
            }

        }

        public int[] GetSlots()
        {
            return slots;
        }

        public void GetRandomItem() 
        {
            Random rand = new Random();
            int id = rand.Next(0, items.Count);
            {
                items[id].Count++;
            }
        }

        public int GetCountItems()
        {
            return items.Count();
        }

        public Item GetItem(string name)
        {
            int id = 0;
            if (db.TryGetValue(name, out id))
            {
                return items[id];
            }
            else
            {
                MessageBox.Show("error");
                return null;
            }
        }

        public Item GetItem(int index)
        {
            if (index < 0 || index > items.Count) return null;
            return items[index];
        }
    }
}
