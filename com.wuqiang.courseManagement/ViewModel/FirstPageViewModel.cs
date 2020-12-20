using com.wuqiang.courseManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wuqiang.courseManagement.ViewModel
{
    public class FirstPageViewModel: NotifyBase
    {
        private Random mRandom = new Random();
        private IList<Task> taskList = new List<Task>();
        private bool bTaskSwitch = true;
        private int _instrumentValue;

        public int InstrumentValue
        {
            get { return _instrumentValue; }
            set { _instrumentValue = value;
                this.DoNotify();
            }
        }

        public FirstPageViewModel()
        {
            this.RefrushInstrumentValue();
        }

        private void RefrushInstrumentValue()
        {
            Task task = Task.Factory.StartNew(async ()=> {

                while (bTaskSwitch)
                {
                    InstrumentValue = mRandom.Next(Math.Max(this.InstrumentValue - 5, -10), Math.Min(this.InstrumentValue + 5, 90));
                    await Task.Delay(1000);
                }
            });
            taskList.Add(task);
        }

        public void Dispose()
        {
            try
            {
                this.bTaskSwitch = false;
                Task.WaitAll(taskList.ToArray());
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
