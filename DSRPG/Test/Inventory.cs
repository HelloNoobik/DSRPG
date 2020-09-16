using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace DSRPG.Test
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
            Save();
        }
        BitmapImage = new BitmapImage
        private void Load() 
        {
            int index = 0;
            db.Add("Эстус", index++);
            items.Add(new Item("Эстус", itemtype.item, 0.0, "/DSRPG;component/Resources/img/Items/Estus.png"));
            db.Add("Человечность", index++);
            items.Add(new Item("Человечность", itemtype.item, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Душа безымянного солдатаа", index++);
            items.Add(new Item("Душа безымянного солдата", itemtype.item, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Небесное благословение", index++);
            items.Add(new Item("Небесное благословение", itemtype.item, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Черная огненная бомба", index++);
            items.Add(new Item("Черная огненная бомба", itemtype.item, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Огненная бомба", index++); 
            items.Add(new Item("Огненная бомба", itemtype.item, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Кинжал", index++);
            items.Add(new Item("Кинжал", itemtype.weapon, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Короткий меч", index++);
            items.Add(new Item("Короткий меч", itemtype.weapon, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Длинный меч", index++); 
            items.Add(new Item("Длинный меч", itemtype.weapon, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Палаш", index++);
            items.Add(new Item("Палаш", itemtype.weapon, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Сет Вора", index++);
            items.Add(new Item("Сет Вора", itemtype.armor, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Сет Воина", index++);
            items.Add(new Item("Сет Воина", itemtype.armor, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Сет Волшебника", index++);
            items.Add(new Item("Сет Волшебника", itemtype.armor, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
            db.Add("Сет Клирика", index++);
            items.Add(new Item("Сет Клирика", itemtype.armor, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
        }

        private void Save() 
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("items");
            xmlDoc.AppendChild(rootNode);
            List<string> names = new List<string>();

            foreach (Item item in items)
            {
                names.Add(item.Name);
                XmlNode userNode = xmlDoc.CreateElement("item");
                XmlAttribute attribute = xmlDoc.CreateAttribute("name");
                attribute.Value = item.Name;
                userNode.Attributes.Append(attribute);
                attribute = xmlDoc.CreateAttribute("itemtype");
                attribute.Value = item.Type.ToString();
                userNode.Attributes.Append(attribute);
                attribute = xmlDoc.CreateAttribute("image");
                attribute.Value = item.Image;
                userNode.Attributes.Append(attribute);
                rootNode.AppendChild(userNode);
            }
            xmlDoc.Save("Items.xml");

            xmlDoc = new XmlDocument();
            rootNode = xmlDoc.CreateElement("db");
            xmlDoc.AppendChild(rootNode);

            foreach (KeyValuePair<string,int> item in db)
            {
                XmlNode userNode = xmlDoc.CreateElement("KeyValuePair");
                XmlAttribute attribute = xmlDoc.CreateAttribute("key");
                attribute.Value = item.Key;
                userNode.Attributes.Append(attribute);
                attribute = xmlDoc.CreateAttribute("value");
                attribute.Value = item.Value.ToString();
                userNode.Attributes.Append(attribute);
                rootNode.AppendChild(userNode);
            }

            xmlDoc.Save("db.xml");
            File.WriteAllLines("names.txt", names.ToArray());
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
