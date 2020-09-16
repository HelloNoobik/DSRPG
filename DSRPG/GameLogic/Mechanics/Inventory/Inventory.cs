using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace DSRPG.GameLogic.Mechanics
{
    public class Inventory
    {
        private List<Item> items;
        private Dictionary<string, int> db;
        private int index;

        public Inventory()
        {
            db = new Dictionary<string, int>();
            items = new List<Item>();

            Load();
        }
        private void Load()
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
                db.Add(key, value);
            }

            XMLdb = new XmlDocument();
            XMLdb.Load("Data/items.xml");
            root = XMLdb.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                string name = "";
                ItemType Type = ItemType.Other;
                string image = "";
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
                        }
                    }
                    else if (atribute.Name == "iamge") image = atribute.Value;
                }
                items.Add(new Item(name, Type, image));
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
    }
}
