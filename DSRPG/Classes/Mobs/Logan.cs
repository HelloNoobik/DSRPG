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
    public class Logan:Mobsbase
    {
        public Logan(BattleArena arena) : base(arena)
        {
            health = 250;
            mana = 0;
            energy = 0;
            damage = 0;
            armor = 0.2;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/logan.png", UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588, 20, 0, 0);
        }
        public override string UpMob()
        {
            energy += 10;
            if(energy == 20)
            {
                energy = 110;
                return "Логан повышает себе энергию !";
            }
            if(energy == 140)
            {
                damage += 50;
                return "Логан тратит свою энергию на повышение урона !";
            }
            if(energy == 160)
            {
                armor = 1;
                return "Логан тратит свою энергию на поглощения урона !";
            }
            if(energy == 180)
            {
                armor = 0;
                energy = 0;
                return "Логан сбросил силы своей энергии !";
            }
            return "Логан копит энергию !";
        }
    }
}
