using com.wuqiang.courseManagement.Common;
using com.wuqiang.courseManagement.Model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<CourseSeriesModel> CourseSeriesList { get; set; } = new ObservableCollection<CourseSeriesModel>();


        public FirstPageViewModel()
        {
            this.RefrushInstrumentValue();
            InitCourseSeriesList();
        }

        private void InitCourseSeriesList()
        {
            //throw new NotImplementedException();
            CourseSeriesList.Add(new CourseSeriesModel()
            {
                CourseName = "深入浅出WPF",
                SeriesCollections = new LiveCharts.SeriesCollection() {
                    new PieSeries() { Title="刘铁锰",
                        Values =new ChartValues<ObservableValue>() {
                            new ObservableValue(123)},
                        DataLabels=false
                    } },
                SeriesList = new ObservableCollection<SeriesModel>() {
                    new SeriesModel() { SeriesName="模板",CurrentValue=12,IsGrowing=false,ChangeRate=24 },
                     new SeriesModel() { SeriesName="样式",CurrentValue=72,IsGrowing=true,ChangeRate=25 }
                }
            });


            CourseSeriesList.Add(new CourseSeriesModel()
            {
                CourseName = "深入浅出WPF",
                SeriesCollections = new LiveCharts.SeriesCollection() {
                    new PieSeries() { Title="刘铁锰",
                        Values =new ChartValues<ObservableValue>() {
                            new ObservableValue(123)},
                        DataLabels=false
                    } },
                SeriesList = new ObservableCollection<SeriesModel>() {
                    new SeriesModel() { SeriesName="模板",CurrentValue=12,IsGrowing=false,ChangeRate=24 },
                     new SeriesModel() { SeriesName="样式",CurrentValue=72,IsGrowing=true,ChangeRate=25 }
                }
            });

            CourseSeriesList.Add(new CourseSeriesModel()
            {
                CourseName = "深入浅出WPF",
                SeriesCollections = new LiveCharts.SeriesCollection() {
                    new PieSeries() { Title="刘铁锰",
                        Values =new ChartValues<ObservableValue>() {
                            new ObservableValue(123)},
                        DataLabels=false
                    } },
                SeriesList = new ObservableCollection<SeriesModel>() {
                    new SeriesModel() { SeriesName="模板",CurrentValue=12,IsGrowing=false,ChangeRate=24 },
                     new SeriesModel() { SeriesName="样式",CurrentValue=72,IsGrowing=true,ChangeRate=25 }
                }
            });
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
