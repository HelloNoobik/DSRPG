using DSRPG.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DSRPG.Classes.Mobs
{
    public class Thief:Mobsbase
    {
        public Thief(BattleArena arena) : base(arena)
        {
            health = 100;
            mana = 20;
            energy = 20;
            damage = 10;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/Thief.png",UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588,20,0,0);
            CheckDieMob();
        }
    }
}
