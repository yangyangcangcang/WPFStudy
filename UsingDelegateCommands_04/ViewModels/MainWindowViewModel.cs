using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingDelegateCommands_04.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value);
                ExecuteDelegateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _updateText;

        public string UpdateText
        {
            get { return _updateText; }
            set { SetProperty(ref _updateText, value); }
        }

        public DelegateCommand ExecuteDelegateCommand { get; private set; }
        public DelegateCommand<string> ExecuteGenericDelegateCommand { get; private set; }
        public DelegateCommand DelegateCommandObservesProperty { get; private set; }
        public DelegateCommand DelegateCommandObservesCanExecute { get;private set; }

        public MainWindowViewModel()
        {
            this.ExecuteDelegateCommand = new DelegateCommand(Execute, CanExeCute);
            this.DelegateCommandObservesProperty = new DelegateCommand(Execute, CanExeCute).ObservesProperty(() => IsEnabled);

            DelegateCommandObservesCanExecute = new DelegateCommand(Execute).ObservesCanExecute(() => IsEnabled);
            ExecuteGenericDelegateCommand = new DelegateCommand<string>(ExecuteGeneric).ObservesCanExecute(()=>IsEnabled);
        }

        private void ExecuteGeneric(string obj)
        {
            UpdateText = obj;
        }

        private bool CanExeCute()
        {
            return IsEnabled;
        }

        private void Execute()
        {
            UpdateText = $"Update：{DateTime.Now}";
        }
    }
}
