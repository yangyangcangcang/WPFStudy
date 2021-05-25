using com.wuqiang.courseManagement.Common;
using com.wuqiang.courseManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace com.wuqiang.courseManagement.ViewModel
{
    public class LoginViewModel: NotifyBase
    {
        /// <summary>
        /// 关闭login window 事件
        /// </summary>
        public CommandBase CloseWindowsCommandBase { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        public CommandBase LoginCommand { get; set; }

        /// <summary>
        /// 登录信息 
        /// </summary>
        public LoginModel LoginMsgModel { get; set; }

        /// <summary>
        /// 错误信息提示
        /// </summary>
        private string _errorMsg;

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value;
                this.DoNotify();
            }
        }



        public LoginViewModel()
        {
            //创建命令对象
            this.CloseWindowsCommandBase = new CommandBase();

            this.CloseWindowsCommandBase.DoCanExecute = param => {

                return true; 
            };

            this.CloseWindowsCommandBase.DoExecute = param => {
                Window win =  param as Window;
                win?.Close();
            };

            this.LoginMsgModel = new LoginModel();
            //this.LoginMsgModel.UserName = "727633266@qq.com";
            //this.LoginMsgModel.ValidataCode = "3245";
            //this.LoginMsgModel.Pwd = "12453";

            //登录按钮
            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoCanExecute = param => { return true; };
            this.LoginCommand.DoExecute = param => {
                ErrorMsg = string.Empty;
                if (string.IsNullOrEmpty(LoginMsgModel.UserName))
                {
                    ErrorMsg = "请输入用户名！";
                    return;
                }
                if (string.IsNullOrEmpty(LoginMsgModel.Pwd))
                {
                    ErrorMsg = "请输入密码！";
                    return;
                }

                if (string.IsNullOrEmpty(LoginMsgModel.ValidataCode))
                {
                    ErrorMsg = "请输入验证码！";
                    return;
                }

                Application.Current.Dispatcher.Invoke(new Action(() => {

                    Window win = param as Window;
                    if(win==null)
                    {
                        return;
                    }
                    win.DialogResult = true;

                }));

            };
        }

    }
}
