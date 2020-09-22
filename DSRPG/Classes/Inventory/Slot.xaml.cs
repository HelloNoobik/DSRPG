﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class Slot : UserControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Image image;
        private int index;
        private Item item;
        private Canvas canvas;
        private ContextMenu cm;
        private UI.HeroPage page;
        private Label label;

        private delegate void Changed(Slot slot);
        private event Changed SlotChanged;

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

        public Visibility CountVisibility 
        {
            get { return label.Visibility; }
            set { label.Visibility = value; OnPropertyChanged(); }
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


            Binding bind = new Binding("CountVisibility");

            label = new Label();
            label.SetBinding(Label.VisibilityProperty,bind);
            label.HorizontalAlignment = HorizontalAlignment.Right;
            label.VerticalAlignment = VerticalAlignment.Bottom;
            label.Margin = new Thickness(0,0,0,-8);
            label.FontSize = 24;
            label.Foreground = Brushes.White;
            grid.Children.Add(label);
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

        public Slot(int index, UI.HeroPage page) : this()
        {

            Core.Settings.Hero.inv.GetItem(index).ItemChanged += Slot_ItemChanged;
            this.item = Core.Settings.Hero.inv.GetItem(index);
            label.Content = item.Count;
            this.index = index;
            this.canvas = page.InventoryWindow;
            this.page = page;
            Source = new BitmapImage(new Uri(this.item.Image, UriKind.Relative));
            canvas.Children.Add(this);

            cm = item.Type == ItemType.Weapon || item.Type == ItemType.Armor ? this.FindResource("WearbleMenu") as ContextMenu : item.Type == ItemType.Item ? this.FindResource("ItemMenu") as ContextMenu : this.FindResource("UsableMenu") as ContextMenu;
            cm.PlacementTarget = this;

            MouseRightButtonDown += Slot_MouseRightButtonDown;

            if (item.Type == ItemType.Weapon || item.Type == ItemType.Armor)
            {
                MenuItem menuItem = cm.Items[0] as MenuItem;
                menuItem.Click += (s, ee) => { Wear(); };
            }
            else if (item.Type == ItemType.Item)
            {
                MenuItem menu = cm.Items[0] as MenuItem;
                for (int i = 0; i < menu.Items.Count; i++)
                {
                    MenuItem menuItem = menu.Items[i] as MenuItem;
                    menuItem.Click += (s, ee) => { Wear(menuItem.Header.ToString()); };
                }
            }
            else 
            {
                MenuItem menuItem = cm.Items[0] as MenuItem;
                menuItem.Click += (s, ee) => { Use(); };
            }
        }

        private void Use() 
        {
            MessageBox.Show("Вжух и готово");
        }

        private void Slot_ItemChanged()
        {
            this.item = Core.Settings.Hero.inv.GetItem(index);
            label.Content = item.Count;
            SlotChanged?.Invoke(this);
        }

        private void Wear(string name = "") 
        {
            if (this.item.Type == ItemType.Armor)
            {
                page.Armor.SetSlot(this.Clone());
                Core.Settings.Hero.inv.Armor = index;
            }
            else if (this.item.Type == ItemType.Weapon)
            {
                page.Weapon.SetSlot(this.Clone());
                Core.Settings.Hero.inv.Weapon = index;
            }
            else
            {
                switch (name)
                {
                    case "Слот 1":
                        Core.Settings.Hero.inv.Slot1 = index;
                        page.slot1.SetSlot(this.Clone());
                        break;
                    case "Слот 2":
                        Core.Settings.Hero.inv.Slot2 = index;
                        page.slot2.SetSlot(this.Clone());
                        break;
                    case "Слот 3":
                        Core.Settings.Hero.inv.Slot3 = index;
                        page.slot3.SetSlot(this.Clone());
                        break;
                    case "Слот 4":
                        Core.Settings.Hero.inv.Slot4 = index;
                        page.slot4.SetSlot(this.Clone());
                        break;
                    case "Слот 5":
                        Core.Settings.Hero.inv.Slot5 = index;
                        page.slot5.SetSlot(this.Clone());
                        break;
                    default:
                        break;
                }
            }
        }

        public Slot Clone() 
        {
            return this;
        }

        public void SetSlot(Slot slot) 
        {
            CountVisibility = slot.item.Type == ItemType.Armor || slot.item.Type == ItemType.Weapon ? Visibility.Hidden : Visibility.Visible;
            image.Source = slot.image.Source;
            label.Content = slot.label.Content;
            item = slot.item;
            slot.SlotChanged += Slot_SlotChanged;
        }

        public void SetSlot(Item item)
        {
            image.Source = new BitmapImage(new Uri(item.Image,UriKind.Relative));
            label.Content = item.Count;
            this.item = item;

            item.ItemChanged += Item_ItemChanged;
        }

        private void Item_ItemChanged()
        {
            label.Content = Core.Settings.Hero.inv.GetItem(index).Count;
        }

        private void Slot_SlotChanged(Slot slot)
        {
            label.Content = slot.label.Content;
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
            if (item != null) BorderBrush = Brushes.Yellow;
            else BorderBrush = Brushes.Red;
        }
    }
}
