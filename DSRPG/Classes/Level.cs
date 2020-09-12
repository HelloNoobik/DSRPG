using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DSRPG.Classes
{
    class Level : Image
    {
        static int Count = 0;
        private int Index;

        public Level(double X, double Y) : base()
        {
            this.Margin = new Thickness(X, Y, 0, 0);
            Index = Count++;
        }
    }
}
