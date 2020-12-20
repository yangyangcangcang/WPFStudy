using com.wuqiang.courseManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wuqiang.courseManagement.Model
{
    public class LoginModel: NotifyBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value;
                this.DoNotify();
            }
        }

        private string _pwd;

        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value;
                this.DoNotify();
            }
        }

        private string _validataCode;

        public string ValidataCode
        {
            get { return _validataCode; }
            set { _validataCode = value;
                this.DoNotify();
            }
        }


    }
}
