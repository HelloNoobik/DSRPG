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
    public class FunnyKnight:Mobsbase
    {
        public FunnyKnight(BattleArena arena) : base(arena)
        {
            health = 350;
            mana = 0;
            energy = 0;
            damage = 25;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/funny knight.png", UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588, 20, 0, 0);
            cost = 20000;
        }
        public override string UpMob()
        {
            energy += 20;
            if(energy >= 20)
            {
                health += 10; 
            }
            if(energy >= 60)
            {
                energy += 10;
            }
            if(energy >= 100)
            {
                damage = 40;
            }
            if(energy == 160)
            {
                damage = 25;
                energy = 0;
            }
            return "Пьяный рыцарь хмелеет\n";
        }
    }
}
