using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace DSRPG.Classes
{
    public class Inventory
    {
        private static List<Item> _items = new List<Item>();
        private static Dictionary<string, int> _db = new Dictionary<string, int>();
        private List<Item> items;
        private Dictionary<string, int> db;
        private int index;

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
            XmlDocument XMLdb = new XmlDocument();
            XMLdb.Load("Data/db.xml");
            XmlElement root = XMLdb.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                string key = "";
                int value = 0;
                foreach (XmlAttribute atribute in node.Attributes)
                {
                    if (atribute.Name == "key") key = atribute.Value;
                    else if (atribute.Name == "value") value = Convert.ToInt32(atribute.Value);
                }
                _db.Add(key, value);
            }

            XMLdb = new XmlDocument();
            XMLdb.Load("Data/items.xml");
            root = XMLdb.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                string name = "";
                ItemType Type = ItemType.Other;
                string image = "";
                int damage = 0;
                double defence = 0.1;
                foreach (XmlAttribute atribute in node.Attributes)
                {
                    if (atribute.Name == "name") name = atribute.Value;
                    else if (atribute.Name == "itemtype")
                    {
                        switch (atribute.Value)
                        {
                            case "item":
                                Type = ItemType.Item;
                                break;
                            case "weapon":
                                Type = ItemType.Weapon;
                                break;
                            case "armor":
                                Type = ItemType.Armor;
                                break;
                            case "other":
                                Type = ItemType.Other;
                                break;
                        }
                    }
                    else if (atribute.Name == "image") image = atribute.Value;
                    else if (atribute.Name == "damage") damage = Convert.ToInt32(atribute.Value);
                    else if (atribute.Name == "defence") defence = Convert.ToDouble(atribute.Value);
                }
                if (Type == ItemType.Armor) _items.Add(new Armor(name, image, defence));
                else if (Type == ItemType.Weapon) _items.Add(new Weapon(name, image, damage));
                else _items.Add(new Item(name, Type, image));

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
            }
            return items[index];
        }

        public Item GetItem(int index)
        {
            if (index < 0 || index > items.Count) return null;
            return items[index];
        }
    }
}
