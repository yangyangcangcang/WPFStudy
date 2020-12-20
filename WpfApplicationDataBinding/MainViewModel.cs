using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationDataBinding
{
    public class MainViewModel:INotifyPropertyChanged
    {
        public string Text { get; set; } = "ABC";

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged("Name");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public MainViewModel()
        {
            Name = "Hello";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
