using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication5
{
    public  class MainViewModel:INotifyPropertyChanged
    {
        private string  _name;

        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged("Name");
            }
        }


        public MainViewModel() {
            Name = "MainViewModel";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
