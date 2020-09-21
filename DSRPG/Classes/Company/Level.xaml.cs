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

namespace DSRPG.Classes.Company
{
    public partial class Level : UserControl
    {
        private Image image;
        private UI.Lotrik page;
        private int index;

        public Size Size 
        {
            get { return new Size(Width, Height); }
            set 
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        public Level()
        {
            InitializeComponent();
            Width = 50;
            Height = 50;

            VerticalAlignment = VerticalAlignment.Top;
            HorizontalAlignment = HorizontalAlignment.Left;

            MouseLeftButtonDown += Level_MouseLeftButtonDown;
            MouseEnter += Level_MouseEnter;
            MouseLeave += Level_MouseLeave;

            image = new Image();
            image.Height = Height;
            image.Width = Width;
            grid.Children.Add(image);
        }

        private void Level_MouseLeave(object sender, MouseEventArgs e)
        {
            if (index == Core.Settings.PositionInCompaign)
            {
                image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/lvl (2).png", UriKind.Relative));
            }
        }

        private void Level_MouseEnter(object sender, MouseEventArgs e)
        {
            if (index == Core.Settings.PositionInCompaign)
            {
                image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/lvl_active.png", UriKind.Relative));
            }
        }

        private void Level_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (index == Core.Settings.PositionInCompaign)
            {
                Core.Settings.PageController.ChangeWindow(Pages.BattleArena);
            }
        }

        public Level(int index,Point point, UI.Lotrik page) : this()
        {
            this.index = index;
            this.page = page;

            Margin = new Thickness(point.X, point.Y, 0, 0);

            page.grid.Children.Add(this);

            Update();
            Core.Settings.PositionChanged += Update;
            Core.Settings.HeroPageStateChanged += Settings_HeroPageStateChanged;
        }

        private void Settings_HeroPageStateChanged()
        {
            if (Core.Settings.HeroPageIsOpened) 
            {
                Visibility = Visibility.Hidden;
            }
            else 
            {
                Visibility = Visibility.Visible;
            }

        }

        private void Update()
        {
            int pos = Core.Settings.PositionInCompaign;
            if (index < pos || index > pos + 1)
            {
                if (index < pos)
                {
                    Visibility = Visibility.Visible;
                    Opacity = 0.2;
                    image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/noPass_active.png", UriKind.Relative));
                }
                else 
                { 
                    Visibility = Visibility.Hidden;
                }
            }
            else 
            {
                Visibility = Visibility.Visible;
                if (index == pos - 1)
                {
                    
                    Opacity = 0.7;
                    image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/lvl (2).png", UriKind.Relative));
                }
                else if (index == pos)
                {
                    Opacity = 1.0;
                    image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/lvl (2).png", UriKind.Relative));
                }
                else 
                {
                    Opacity = 0.7;
                    image.Source = new BitmapImage(new Uri("/DSRPG;component/Resources/img/noPass.png", UriKind.Relative));
                }
            } 
        }
    }
}
