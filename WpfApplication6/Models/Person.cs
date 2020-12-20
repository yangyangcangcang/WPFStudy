using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication6.Models
{
    public class Person:ViewModelBase
    {
        private int id;

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
            get { return id; }
            set { id = value;
                RaisePropertyChanged();
            }
        }

    }
}
