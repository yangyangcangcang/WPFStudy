using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEventAggregator.Core;

namespace ModuleAEvent.ViewModels
{
   public  class MessageViewModel:BindableBase
    {

        private readonly IEventAggregator _eventAggregator1;

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }


        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageViewModel(IEventAggregator eventAggregator)
        {
            this._eventAggregator1 = eventAggregator;
            SendMessageCommand = new DelegateCommand(Execute);
        }

        private void Execute()
        {
            this._eventAggregator1.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
