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
    public class Gyndir:Mobsbase
    {
        public Gyndir(BattleArena arena) : base(arena)
        {
            health = 900;
            mana = 0;
            energy = 0;
            armor = 0.5;
            damage = 50;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/gyndir.png", UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588, 20, 0, 0);
        }
        public override string UpMob()
        {
            energy += 50;
            if(energy == 50)
            {
                damage = 70;
            }
            if(energy == 100)
            {
                damage = 0;
                armor += 0.3;
            }
            if(energy == 200)
            {
                damage = 15;
                armor = 0.8;
            }
            if(energy == 400)
            {
                damage = 50;
                armor = 0.5;
                energy = 0;
                energy += 30;
            }
            return "Гундир босс ";
        }
    }
}
