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
    public class MainWindowViewModel:BindableBase
    {

        private DelegateCommand _showDialogCommand;

        private readonly IDialogService _DialogService;

        public DelegateCommand ShowDialogCommand => _showDialogCommand ?? (_showDialogCommand = new DelegateCommand(ShowDialog));

        private string _title = "Prism";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title,value); }
        }



        private void ShowDialog()
        {
            string message = "This is a Message that should be shown in dialog";

            this._DialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), r => {

                if (r.Result == ButtonResult.None)
                    Title = "Result is None";
                else if (r.Result == ButtonResult.OK)
                    Title = "Result is OK";
                else if (r.Result == ButtonResult.Cancel)
                    Title = "Result is Cancel";
                else
                    Title = "I Don't know what you did!?";

            });
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            this._DialogService = dialogService;
        }

    }
}
