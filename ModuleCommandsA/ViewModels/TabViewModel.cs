using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Unity;
using UsingCompositeCommands.Core;
using Prism;

namespace ModuleCommandsA.ViewModels
{
    public class TabViewModel:BindableBase,IActiveAware
    {
        private readonly IApplicationCommands _applicationCommands = null;

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _canUpdate;

        public bool CanUpdate
        {
            get { return _canUpdate; }
            set { SetProperty(ref _canUpdate, value); }
        }

        private string _updateText;

        public string UpdateText
        {
            get { return _updateText; }
            set { SetProperty(ref _updateText, value); }
        }


        public DelegateCommand UpdateCommand { get; private set; }

        public TabViewModel(IApplicationCommands applicationCommands)
        {
            this._applicationCommands = applicationCommands;
            this.UpdateCommand = new DelegateCommand(Execute).ObservesCanExecute(() => CanUpdate);

            applicationCommands.SaveCommand.RegisterCommand(UpdateCommand);
        }

        private void Execute()
        {
            UpdateText = $"Update：{DateTime.Now}";
        }

        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value;
                OnIsActiveChanged();
            }
        }

        private void OnIsActiveChanged()
        {
            this.UpdateCommand.IsActive = IsActive;
            IsActiveChanged?.Invoke(this, new EventArgs());
        }
        public event EventHandler IsActiveChanged;
    }
}
