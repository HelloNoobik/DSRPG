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
    public class Knight:Mobsbase
    {
        public Knight(BattleArena arena) : base(arena)
        {
            health = 150;
            mana = 0;
            energy = 0;
            damage = 13;
            armor = 0;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/knight.png", UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588, 20, 0, 0);
            cost = 5000;
        }
        public override string UpMob()
        {
            energy += 10;
            if(energy == 30)
            {
                armor = 0.5;
                damage = 0;
                return "Рыцарь становится в защитную стойку!\n";

            }
            if(energy == 50)
            {
                armor = 0;
                damage = 13;
                return "Рыцарь вышел из защитной стойки!\n";
            }
            if (energy == 100)
            {
                damage = 50;
                return "Рыцарь в ярости!\n";
            }
            if(energy == 120)
            {
                damage = 0;
                energy -= 120;
                return "Рыцарь выдохся!\n";
            }
            Random rand = new Random();
            string[] result = new string[] { "Рыцарь отдаёт честь", "Рыцарь признаёт в вас достойного врага", "Рыцарь показывать жест" };
            return result[rand.Next(0, result.Length)] + "\n";
        }

    }
}
