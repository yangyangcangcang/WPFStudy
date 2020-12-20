using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationDataBinding
{

    public class MainWindowMvvm :ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
                RaisePropertyChanged();//提高 升起
            }
        }


        public RelayCommand SaveCommand { get; set; }

        public MainWindowMvvm()
        {
            Name = "Hello  mvvm";
            SaveCommand = new RelayCommand(() => {
                Name = "World";
            });
        }



    }
}
