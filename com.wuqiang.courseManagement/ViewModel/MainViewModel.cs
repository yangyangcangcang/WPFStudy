using com.wuqiang.courseManagement.Common;
using com.wuqiang.courseManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace com.wuqiang.courseManagement.ViewModel
{
    public class MainViewModel:NotifyBase
    {
        public UserModel UserInfo { get; set; }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value;
                this.DoNotify();
            }
        }

        private FrameworkElement _mainContent;

        public FrameworkElement MainContent
        {
            get { return _mainContent; }
            set { _mainContent = value;
                this.DoNotify();
            }
        }

        public CommandBase NavChangedCommand { get; set; }

        public MainViewModel()
        {
            this.NavChangedCommand = new CommandBase();
            this.NavChangedCommand.DoExecute = new Action<object>(DoNavChanged);
            this.NavChangedCommand.DoCanExecute = new Func<object, bool>(o => true);

            this.DoNavChanged("FirstPageView");
        }

        private void DoNavChanged(object obj)
        {
            Type type = Type.GetType($"com.wuqiang.courseManagement.View.{obj.ToString()}");
            ConstructorInfo constructorInfo = type.GetConstructor(Type.EmptyTypes);
            this.MainContent = (FrameworkElement)constructorInfo.Invoke(null);
        }
    }
}
