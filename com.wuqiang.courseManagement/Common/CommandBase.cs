using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace com.wuqiang.courseManagement.Common
{

     
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Action<Object> DoExecute { get; set; }

        public Func<Object,bool> DoCanExecute { get; set; }



        public bool CanExecute(object parameter)
        {
            return this.DoCanExecute?.Invoke(parameter) == true;
        }

        public void Execute(object parameter)
        {
            this.DoExecute?.Invoke(parameter);
        }
    }
}
