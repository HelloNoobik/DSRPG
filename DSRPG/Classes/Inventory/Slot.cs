using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DSRPG.Classes
{ 
    class Slot
    {
        private string name;
        private Image img;
        private Rectangle rect;
        private Point point;
        private Size size;

        public string Name 
        {
            get 
            {
                return name;
            }

            private set 
            {
                name = value;
            }
        }
        public Point Point 
        {
            get { return point; }
            set 
            { 
                point = value;
                PointChanged();
            }
        }
        public Size Size 
        {
            get { return size; }
            set 
            { 
                size = value;
                SizeChanged();
            }
        }

        private bool mousePressed = false;

        private delegate void Changed();
        private event Changed PointChanged;
        private event Changed SizeChanged;

        public event MouseEventHandler MouseEnter;
        public event MouseEventHandler MouseLeave;
        public event MouseButtonEventHandler MouseLeftMouseDown;
        public event MouseButtonEventHandler MouseLeftMouseUp;

        public Slot(string name,Point point,Size size,BitmapImage img, Canvas cnv) 
        {
            this.name = name;
            this.point = point;
            this.size = size;

            this.img = new Image();
            this.img.Source = img;
            this.img.Height = size.Height;
            this.img.Width = size.Width;
            Canvas.SetLeft(this.img, this.point.X);
            Canvas.SetTop(this.img, this.point.Y);

            rect = new Rectangle();
            rect.Height = this.size.Height;
            rect.Width = this.size.Width;
            rect.Stroke = Brushes.White;
            Canvas.SetLeft(rect, this.point.X);
            Canvas.SetTop(rect, this.point.Y);

            this.img.MouseLeftButtonDown += MouseLeftButtonDownImg;
            this.img.MouseLeftButtonUp += MouseLeftButtonUpImg;
            this.img.MouseEnter += MouseEnterImg;
            this.img.MouseLeave += MouseLeaveImg;
            SizeChanged += UpdateSize;
            PointChanged += UpdateCoords;

            cnv.Children.Add(this.img);
            cnv.Children.Add(rect);
        }

        private void UpdateCoords() 
        {
            Canvas.SetLeft(img, point.X);
            Canvas.SetTop(img, point.Y);
            Canvas.SetLeft(rect, point.X);
            Canvas.SetTop(rect, point.Y);
        }
        private void UpdateSize() 
        {
            img.Height = size.Height;
            img.Width = size.Width;
            rect.Height = size.Height;
            rect.Width = size.Width;
        }

        public void ChangeBorder(SolidColorBrush color) 
        {
            rect.Stroke = color;
        }

        public static Image DragDrop() 
        {
            return buf.img;
        }

        private void MouseEnterImg(object sender, MouseEventArgs e) 
        {
            MouseEnter?.Invoke(this, e);
        }


        private static Slot buf;
        private void MouseLeaveImg(object sender, MouseEventArgs e)
        {
            if (mousePressed) 
            {
                mousePressed = false;
                buf = this;
            }
            MouseLeave?.Invoke(this, e);
        }

        private void MouseLeftButtonDownImg(object sender, MouseButtonEventArgs e)
        {
            mousePressed = true;
            MouseLeftMouseDown?.Invoke(this, e);
        }

        private void MouseLeftButtonUpImg(object sender, MouseButtonEventArgs e)
        {
            mousePressed = false;
            MouseLeftMouseUp?.Invoke(this, e);
        }
    }
}
