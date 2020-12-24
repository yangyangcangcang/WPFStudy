using com.wuqiang.courseManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wuqiang.courseManagement.ViewModel
{
    public class CoursePageViewModel
    {
        public ObservableCollection<CategoryItemModel> CategoryCourses { get; set; }

        public ObservableCollection<CategoryItemModel> CategoryTechnology { get; set; }

        public ObservableCollection<CategoryItemModel> CategoryTeacher { get; set; }

        public CoursePageViewModel()
        {
            CategoryCourses = new ObservableCollection<CategoryItemModel>();
            CategoryCourses.Add(new CategoryItemModel() {CategoryName="全部",IsSelected=true });
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

        }
    }
}
