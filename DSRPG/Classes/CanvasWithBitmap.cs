using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DSRPG.Classes
{
    class CanvasWithBitmap : Canvas
    {
        public Point Location;
        public CanvasWithBitmap(string path)
        {
            image = new BitmapImage(new Uri($@"{path}"));
            Location = new Point(0, 0);
        }

        protected override void OnRender(DrawingContext dc)
        {
            dc.DrawImage(image,
                new Rect(Location.X, Location.Y, image.PixelWidth, image.PixelHeight));
        }

        private BitmapImage image;
    }
}
