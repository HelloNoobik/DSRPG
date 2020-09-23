
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DSRPG.Classes.Hero;
using DSRPG.Core;
using DSRPG.Test;
using DSRPG.Classes;
using DSRPG.Classes.Mobs;
using DSRPG.Classes.Arena;
using System.Windows.Media.Animation;
using System.Configuration;

namespace DSRPG.UI
{
    /// <summary>
    /// Логика взаимодействия для BattleArena.xaml
    /// </summary>
    public partial class BattleArena : Page
    {
        static private Battle battle;
        public BattleArena()
        {
            InitializeComponent();
            battle = new Battle(new Thief(this), this);


        }

        private void hp_Click(object sender, RoutedEventArgs e)
        {
            battle.Hero.Health.Current--;
            battle.Hero.Mana.Current--;
            battle.Hero.Energy.Current--;
            battle.Mob.Health--;
            battle.Mob.Mana--;
            battle.Mob.Energy--;
        }

    } 
}
