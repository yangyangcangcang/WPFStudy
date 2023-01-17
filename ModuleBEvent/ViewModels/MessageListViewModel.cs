using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingEventAggregator.Core;

namespace ModuleBEvent.ViewModels
{
   public class MessageListViewModel:BindableBase
    {

        private readonly IEventAggregator _EventAggregator;

        private ObservableCollection<string> _massage;

        public ObservableCollection<string> Messages
        {
            get { return _massage; }
            set { SetProperty(ref _massage, value);  }
        }

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            this._EventAggregator = eventAggregator;
            Messages = new ObservableCollection<string>();
            //this._EventAggregator.GetEvent<MessageSentEvent>().Subscribe(x => {
            //    Messages.Add(x);
            //});

            //带有过滤功能的
            this._EventAggregator.GetEvent<MessageSentEvent>().Subscribe(x => { Messages.Add(x); }, ThreadOption.PublisherThread, false, (filter) =>  filter.Contains("Brian"));
        }


    }
}
