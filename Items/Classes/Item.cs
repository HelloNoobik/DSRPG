using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDll.Enums;

namespace InventoryDll.Classes
{
    public class Item
    {
        public string Title { get; private protected set; }
        public string Description { get; private protected set; }
        public string Weight { get; private protected set; }

        public ItemsType ItemType { get; private protected set; }


        public Item(string Title, string Desc, string Weight) 
        {
            this.Title = Title;
            this.Description = Desc;
            this.Weight = Weight;
        }
    }
}
