using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Test
{
    public class Inventory
    {
        public List<item> items = new List<item>();



        public Inventory()
        {
            items.Add(new item("123", itemtype.item, 2, DSRPG.Resources.Links.Img.YellowLevel.ToString()));
        }
    }
}
