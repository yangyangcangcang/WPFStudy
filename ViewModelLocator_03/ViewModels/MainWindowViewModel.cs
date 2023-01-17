using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLocator_03.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        private string _title="Prism Unity Application";

        public string Title
        {
            get { return _title; }
            set { SetProperty<string>(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }

    }
}
