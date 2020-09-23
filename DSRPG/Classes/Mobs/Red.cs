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
    public class Red:Mobsbase
    {
        public Red(BattleArena arena) : base(arena)
        {
            health = 250;
            mana = 70;
            energy = 40;
            damage = 20;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/red.png", UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588, 20, 0, 0);
        }
    }
}
