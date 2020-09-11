using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DSRPG
{
    delegate void Changed();
    static class Settings
    {
        static public event Changed VolumeChanged;
        static private double volume = 0.1;
        static public double Volume 
        {
            get 
            {
                return volume;
            }

            set
            {
                if (value > 1.0) volume = 1.0;
                else if (value < 0.0) volume = 0.0;
                else volume = value;
                VolumeChanged();
            }
        }
    }
}
