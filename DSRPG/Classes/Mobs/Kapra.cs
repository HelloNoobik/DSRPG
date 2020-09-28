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
    public class Kapra:Mobsbase
    {
        public Kapra(BattleArena arena) : base(arena)
        {
            health = 300;
            mana = 50;
            energy = 200;
            damage = 0;
            armor = 0.07;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/kapra.png", UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588, 20, 0, 0);
            cost = 20000;
        }
        public override string UpMob()
        {
            if(energy == 200)
            {
                damage = 50;
                energy = 180;
                return "Дабл урон!\n";
            }
            if(energy == 180)
            {
                damage = 50;
                energy = 130;
                return "Дабл урон!\n";
            }
            if(energy == 130)
            {
                damage = 0;
                armor = 0.5;
                energy = 50;
                return "Дабл понижение урона\n";
            }
            if(energy == 50)
            {
                damage = 100;
                armor = 0.2;
                energy = 0;
                return "Дабл безысходности !\n";
            }
            if(energy == 0)
            {
                armor = 0;
                damage = 0;
                return "Дабл без сил !\n";
            }
            return "Ничего";
        }
    }
}
