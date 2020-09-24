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
            health = 500;
            mana = 0;
            energy = 0;
            damage = 10;
            armor = 0.4;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/boss anatolii.png", UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588, 20, 0, 0);
        }
        public override string UpMob()
        {
            energy += 10;
            if(energy >= 20)
            {
                armor += 0.02;
            }
            if(energy >= 60)
            {
                health += 15;
            }
            if(energy == 100)
            {
                damage = 40;
            }
            if(energy == 120)
            {
                damage = 0;
                armor = 1;
            }
            if(energy == 150)
            {
                damage = 100;
                armor = -0.3;
                energy = 0;
            }
            return "Анатолий играет от щита !";
        }
    }
}
