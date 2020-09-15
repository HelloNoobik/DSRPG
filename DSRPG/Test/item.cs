using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DSRPG.Test
{
    public enum itemtype
    {
        item,armor,weapon,spell,other
    }
    public class Item
    {
        private string name;
        private itemtype type;
        private double weight;
        private int count;
        private string image;


        public string Image
        {
            get { return image; }
        }
        public string Name
        {
            get { return name; }
        }

        public itemtype Type
        {
            get
            {
                return type;
            }
        }

        public double Weight
        {
            get { return weight; }
        }

        public int Count
        {
            get { return count; }
            set
            {
                if (count >= 100) return;
                if (count + value > 100)
                {
                    count = 100;
                    return;
                }  
                count += value;
            }
        }
        public Item(string name,itemtype type,double weight,string image,int count = 1)
        {
            this.name = name;
            this.type = type;
            this.weight = weight;
            this.image = image;
            Count = count;
        }
    }
}
