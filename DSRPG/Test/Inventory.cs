using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DSRPG.Test
{
    public class Inventory
    {
        private List<Item> items;
        private Dictionary<string, int> db;
        private int index;

        public Inventory()
        {
            items = new List<Item>();
            db = new Dictionary<string, int>();
            index = 0;
            AddItem(new Item("Эстус", itemtype.item, 0.0, "/DSRPG;component/Resources/img/items/estus.png"));
        }

        public void AddItem(Item item, int count = 1) 
        {
            int id = 0;
            if (db.TryGetValue(item.Name, out id))
            {
                return;
            }
            else 
            {
                MessageBox.Show("error");
            }

        }

        public void RemoveItem(Item item, int count = 1)
        {
            int id = -1;
            db.TryGetValue(item.Name, out id);
            if (id == -1)
            {
                return;
            }
            else
            {
                items[id].Count -= count;
            }

        }

        public int GetCountItems() 
        {
            return items.Count();
        }

        public Item GetItem(int index) 
        {
            return items[index];
        }
    }
}
