using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes.DataClasses
{
    public class StatDouble : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private double max;
        private double current;
        private double _base;

        public double Max
        {
            get { return max; }
            set
            {
                max = value;
            }
        }
        public double Current
        {
            get { return current; }
            set
            {
                current = value;
                if (current <= 0)
                {
                    Empty?.Invoke();
                }
                OnPropertyChanged();
            }
        }

        public double Base
        {
            get { return _base; }
            set
            {
                _base = value;
                OnPropertyChanged();
            }
        }

        public void Reset()
        {
            Current = max;
        }

        public StatDouble(double current)
        {
            this.current = current;
            max = current;
            _base = current;
        }

        public delegate void Event();
        public event Event Empty;

    }
}
