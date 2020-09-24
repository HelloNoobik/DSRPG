using DSRPG.Classes.Hero;
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
            mana = 0;
            energy = 0;
            damage = 10;
            armor = 0;
            image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/mobs/Thief.png",UriKind.Relative));
            page.Room.Children.Add(image);
            image.Margin = new Thickness(588,20,0,0);
        }
        public override string UpMob()
        {
            Energy += 10;
            if (Energy == 30)
            {
                Armor = 0.1;
                Energy += 30;
                return "Вор повышает свою Защиту и Энергию !\n";
            }
            if (Energy == 100)
            {
                Damage = 50;
                Damage -= 100;
                return "Вор в Ярости !\n";
            }
            Random rand = new Random();
            string[] result = new string[] {"Вор ехидно улыбается","Вор ухмыляется","Вор смеётся над вашей беспомощностью"};
            return result[rand.Next(0, result.Length)] + "\n";
        }
    }
}
