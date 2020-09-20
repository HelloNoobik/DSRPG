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

namespace DSRPG.Classes
{
    public partial class Slot : UserControl
    {
        private Image image;
        private Item item;
        private Canvas canvas;
        private ContextMenu cm;
        private UI.HeroPage page;
        public ImageSource Source
        {
            get { return image.Source; }
            set { image.Source = value; }
        }

        public Point Location
        {
            get { return new Point(Canvas.GetLeft(this), Canvas.GetTop(this)); }
            set
            {
                Canvas.SetLeft(this, value.X);
                Canvas.SetTop(this, value.Y);
            }
        }
        public Slot()
        {
            InitializeComponent();
            BorderBrush = Brushes.White;
            BorderThickness = new Thickness(1, 1, 1, 1);
            Width = 50;
            Height = 50;
            Background = Brushes.Transparent;

            SizeChanged += Slotter_SizeChanged;
            MouseEnter += Image_MouseEnter;
            MouseLeave += Image_MouseLeave;

            image = new Image();
            image.Height = Height;
            image.Width = Width;
            grid.Children.Add(image);
        }

        private void Slot_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            cm.IsOpen = true;
        }

        private void Slotter_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            image.Height = Height;
            image.Width = Width;
        }

        public Slot(Item item, UI.HeroPage page) : this()
        {

            this.item = item;
            this.canvas = page.InventoryWindow;
            this.page = page;
            Source = new BitmapImage(new Uri(this.item.Image, UriKind.Relative));
            canvas.Children.Add(this);

            cm = item.Type == ItemType.Weapon || item.Type == ItemType.Armor ? this.FindResource("WearbleMenu") as ContextMenu : this.FindResource("ItemMenu") as ContextMenu;
            cm.PlacementTarget = this;

            MouseRightButtonDown += Slot_MouseRightButtonDown;

            if (item.Type == ItemType.Weapon || item.Type == ItemType.Armor) 
            {
                MenuItem menuItem = cm.Items[0] as MenuItem;
                menuItem.Click += (s, ee) => { Wear(); };
            }
            else
            {
                MenuItem menu = cm.Items[0] as MenuItem;
                for (int i = 0; i < menu.Items.Count; i++) 
                {
                    MenuItem menuItem = menu.Items[i] as MenuItem;
                    menuItem.Click += (s, ee) => { Wear(menuItem.Header.ToString()); };
                }
            }
        }

        private void Wear(string name = "") 
        {
            if (this.item.Type == ItemType.Armor)
            {
                page.Armor.SetSlot(this.Clone());
            }
            else if (this.item.Type == ItemType.Weapon)
            {
                page.Weapon.SetSlot(this.Clone());
            }
            else
            {
                switch (name)
                {
                    case "Слот 1":
                        page.slot1.SetSlot(this.Clone());
                        break;
                    case "Слот 2":
                        page.slot2.SetSlot(this.Clone());
                        break;
                    case "Слот 3":
                        page.slot3.SetSlot(this.Clone());
                        break;
                    case "Слот 4":
                        page.slot4.SetSlot(this.Clone());
                        break;
                    case "Слот 5":
                        page.slot5.SetSlot(this.Clone());
                        break;
                    default:
                        break;
                }
            }
        }

        public Slot Clone() 
        {
            Slot result = new Slot();
            result.item = item;
            result.image = image;
            return result;
        }

        public void SetSlot(Slot slot) 
        {
            image.Source = slot.image.Source;
            item = slot.item;
        }

        public Item GetItem() 
        {
            return item;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            BorderBrush = Brushes.White;
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            BorderBrush = Brushes.Yellow;
        }
    }
}
