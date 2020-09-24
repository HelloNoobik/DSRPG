using DSRPG.Classes.Hero;
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
            health = 600;
            mana = 0;
            energy = 0;
            damage = 1;
            armor = 0;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/red.png", UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588, 20, 0, 0);
        }
        public override string UpMob()
        {
            energy += 10;
            if(energy >= 10)
            {
                damage += 5;
                health -= 50;
            }
            if(energy >= 50)
            {
                armor += 0.1;
            }
            if (energy == 110)
            {
                health += 1000;
                return "Вам ....";
            }
            return "Вторженец копит силы !";
        }
    }
}
