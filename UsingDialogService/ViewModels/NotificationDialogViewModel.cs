using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingDialogService.ViewModels
{
    public class NotificationDialogViewModel : BindableBase, IDialogAware
    {
        private string _title = "Notification Dialog";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        private DelegateCommand<string> _closeDialogCommand;

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand<string> CloseDialogCommand => _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private void CloseDialog(string parameter)
        {
            ButtonResult buttonResult = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                buttonResult = ButtonResult.OK;
            }
            else if (parameter?.ToLower() == "false")
            {
                buttonResult = ButtonResult.Cancel;
            }

            RaisRequestClose(new DialogResult(buttonResult));
        }

        private void RaisRequestClose(DialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        //public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
           
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }
    }
}
