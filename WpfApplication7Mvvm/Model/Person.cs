using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication7Mvvm.Model
{
    public class Person:ViewModelBase
    {
        private int Id;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
                RaisePropertyChanged();
            }
        }


        public int ID
        {
            get { return Id; }
            set { Id = value;
                RaisePropertyChanged();
            }
        }

    }
}
