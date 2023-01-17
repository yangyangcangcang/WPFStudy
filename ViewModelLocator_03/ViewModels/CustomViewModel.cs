using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModelLocator_03.ViewModels
{
    public class CustomViewModel: BindableBase
    {
        private string _title = "CustomViewModel  Bind";

        public string Title
        {
            get { return _title; }
            set { SetProperty<string>(ref _title, value); }
        }

        public CustomViewModel()
        {

        }
    }
}
