using com.wuqiang.courseManagement.Common;
using com.wuqiang.courseManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace com.wuqiang.courseManagement.ViewModel
{
    public class CoursePageViewModel
    {
        public ObservableCollection<CategoryItemModel> CategoryCourses { get; set; }

        public ObservableCollection<CategoryItemModel> CategoryTechnology { get; set; }

        public ObservableCollection<CategoryItemModel> CategoryTeacher { get; set; }

        public ObservableCollection<CourseModel> CourseList { get; set; }

        public CommandBase OpenCourseUrlCommand { get; set; }

        public List<CourseModel> CourseAll { get; set; }

        public CommandBase TeacherFilterCommand { get; set; }

        public CoursePageViewModel()
        {
            InitCourseList();
            this.OpenCourseUrlCommand = new CommandBase();
            this.OpenCourseUrlCommand.DoCanExecute = new Func<object, bool>(t => true);
            this.OpenCourseUrlCommand.DoExecute = new Action<object>(t => { System.Diagnostics.Process.Start(t.ToString()); });


            this.TeacherFilterCommand = new CommandBase();
            this.TeacherFilterCommand.DoCanExecute = new Func<object, bool>(t => true);
            this.TeacherFilterCommand.DoExecute = new Action<object>(DoFilter);

            CategoryCourses = new ObservableCollection<CategoryItemModel>();
            CategoryCourses.Add(new CategoryItemModel() { CategoryName = "全部", IsSelected = true });
            CategoryCourses.Add(new CategoryItemModel() { CategoryName = "VIP课程", IsSelected = false });
            CategoryCourses.Add(new CategoryItemModel() { CategoryName = "公开课", IsSelected = false });

            CategoryTechnology = new ObservableCollection<CategoryItemModel>();
            CategoryTechnology.Add(new CategoryItemModel() { CategoryName = "全部", IsSelected = true });
            CategoryTechnology.Add(new CategoryItemModel() { CategoryName = "C#", IsSelected = false });
            CategoryTechnology.Add(new CategoryItemModel() { CategoryName = "Java", IsSelected = false });
            CategoryTechnology.Add(new CategoryItemModel() { CategoryName = "Python", IsSelected = false });
            CategoryTechnology.Add(new CategoryItemModel() { CategoryName = "C++", IsSelected = false });


            CategoryTeacher = new ObservableCollection<CategoryItemModel>();
            CategoryTeacher.Add(new CategoryItemModel() { CategoryName = "全部", IsSelected = true });
            CategoryTeacher.Add(new CategoryItemModel() { CategoryName = "张三", IsSelected = false });
            CategoryTeacher.Add(new CategoryItemModel() { CategoryName = "李四", IsSelected = false });
            CategoryTeacher.Add(new CategoryItemModel() { CategoryName = "王五", IsSelected = false });
            CategoryTeacher.Add(new CategoryItemModel() { CategoryName = "赵六", IsSelected = false });

            //     public string CourseName { get; set; }
            //public string Cover { get; set; }
            //public string Url { get; set; }
            //public string Description { get; set; }
            //public List<string> Teachers { get; set; }
          


        }

        private void InitCourseList()
        {
            CourseList = new ObservableCollection<CourseModel>();
            for (int i = 0; i < 10; i++)
            {
                CourseList.Add(new CourseModel() { IsShowSkeleton = true });
            }

            Task.Run(new Action(async () =>
            {
                CourseAll = new List<CourseModel>();
                CourseAll.Add(new CourseModel() { CourseName = "红细胞琅琊特战旅", Cover = "", Url = "http://wwww.baidu.com", Description = "好好学习，天天向上", Teachers = new List<string>() { "张三", "李四" } });
                CourseAll.Add(new CourseModel() { CourseName = "Java编程思想", Cover = "", Url = "http://wwww.baidu.com", Description = "好好学习，天天向上1", Teachers = new List<string>() { "张三", "李四" } });
                CourseAll.Add(new CourseModel() { CourseName = "深入浅出MFC", Cover = "", Url = "http://wwww.baidu.com", Description = "好好学习，天天向上2", Teachers = new List<string>() { "张三", "李四" } });
                CourseAll.Add(new CourseModel() { CourseName = "python数据分析", Cover = "", Url = "http://wwww.baidu.com", Description = "好好学习，天天向上3", Teachers = new List<string>() { "张三", "李四" } });
                await Task.Delay(4000);
                
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    CourseList.Clear();
                    foreach (var item in CourseAll)
                    {
                        CourseList.Add(item);
                    }
                }));
            }));
        }


        private void DoFilter(object obj)
        {
            string techerName = obj.ToString();
            var courseList = CourseAll.Where(t => t.Teachers.Exists(e => e == techerName)).ToList();
            courseList.Clear();
            foreach (var item in courseList)
            {
                courseList.Add(item);
            }
        }
    }
}
