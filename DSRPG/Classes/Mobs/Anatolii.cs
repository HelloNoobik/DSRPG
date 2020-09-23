using DSRPG.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DSRPG.Classes.Mobs
{
    public class Anatolii:Mobsbase
    {
        public Anatolii(BattleArena arena) : base(arena)
        {
            health = 999;
            mana = 999;
            energy = 999;
            damage = 999;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/boss anatolii.png", UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588, 20, 0, 0);
        }
    }
}
