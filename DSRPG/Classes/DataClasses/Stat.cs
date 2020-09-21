using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
                current = value; 
                if(current <= 0)
                {
                    Empty?.Invoke();
                }
                OnPropertyChanged();
            }
        }

        public void Reset()
        {
            current = max;
        }

        public Stat(int current)
        {
            this.current = current;
            max = current;
        }

        public delegate void Event();
        public event Event Empty;
        
    }
}
