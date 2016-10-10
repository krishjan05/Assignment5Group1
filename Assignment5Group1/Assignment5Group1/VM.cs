using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Assignment5Group1
{
    class VM : INotifyPropertyChanged
    {
        const string DIRNAME = "PROG8010";
        const string FILENAME = "hour_distance.txt";
        public string Speed
        {
            get { return _speed; }
            set { _speed = value; OnPropertyChanged(); }
        }
        string _speed;

        public string Time
        {
            get { return _time; }
            set { _time = value;  OnPropertyChanged(); }
        }
        string _time;

        public ObservableCollection<Data> MyList
        {
            get { return _myList; }
            set { _myList = value;  OnPropertyChanged(); }
        }
        ObservableCollection<Data> _myList = new ObservableCollection<Data>();

        public void CalcDistance()
        {
            int hours = int.Parse(_time);
            int speed = int.Parse(_speed);
            _myList.Clear();
            int i = 1;
            while (i <= hours){
                Data d = new Data();
                d.hour = i;
                d.distance = i * speed;
                _myList.Add(d);
                i++;
            }            
        }
        public void SaveToFile()
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullpath = Path.Combine(path, DIRNAME);
            Directory.CreateDirectory(fullpath);
            string fullname = Path.Combine(fullpath, FILENAME);
            StreamWriter sw = File.AppendText(fullname);
            foreach(Data d in MyList)
            {
                sw.Write(" ");
                sw.WriteLine(d.ToString());
            }
            sw.Close();
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string caller = "")
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
