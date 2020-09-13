using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DSRPG
{
    static public class Extension
    {
        public static void SetLocation(this Window win,Point point) 
        {
            win.Left = point.X;
            win.Top = point.Y;
        }
        public static Point GetLocation(this Window win) 
        {
            return (new Point(win.Left, win.Top));
        }

    }
}
