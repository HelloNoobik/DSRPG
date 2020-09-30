using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DSRPG.Classes.DataClasses
{
    public class Stat : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int max;
        private int current;
        private int _base;

        public int Max
        {
            get { return max; }
            set 
            {
                max = value;
            }
        }
        public int Current
        {
            get { return current; }
            set 
            {
                if (value < current) Decrease?.Invoke(current - value);
                if (value > max)
                {
                    current = max;
                    OnPropertyChanged();
                    return;
                }
                current = value;
                OnPropertyChanged();
                if (current <= 0)
                {
                    Empty?.Invoke();
                }

            }
        }

        public int Base
        {
            get { return _base; }
            set
            {
                _base = value;
            }
        }

        public void Reset()
        {
            Current = max;
        }

        public void FullReset()
        {
            Current = max;
            _base = max;
        }

        public Stat(int current)
        {
            this.current = current;
            max = current;
            _base = current;
        }

        public Stat()
        {

        }

        public delegate void EventInt(int damage);
        public delegate void Event();
        public event Event Empty;
        public event EventInt Decrease;
        
    }
}
