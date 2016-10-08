using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5Group1
{
    class VM : INotifyPropertyChanged
    {
        int _speed;
        int _time;
        List<int> _myList = new List<int>();

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; OnPropertyChanged(); }
        }

        public int Time
        {
            get { return _time; }
            set { _time = value;  OnPropertyChanged(); }
        }

        public List<int> MyList
        {
            get { return _myList; }
            set { _myList = value;  OnPropertyChanged(); }
        }

        public void CalcDistance()
        {
            for (int i =1; i <= _time; i++)
            {
                _myList.Add(_speed * i);
            }
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            // make sure only to call this if the value actually changes

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
        #endregion
    }
}
