using DSRPG.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DSRPG.Classes
{
    public class Hollow:Mobsbase
    {
        public Hollow(BattleArena arena)
            : base(arena)
        {
            name = "Полый";
            health = 20;
            mana = 0;
            energy = 20;
            damage = 0;
            armor = 0;
        }
    }
}
