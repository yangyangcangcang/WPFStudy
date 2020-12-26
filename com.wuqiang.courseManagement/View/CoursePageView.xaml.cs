using com.wuqiang.courseManagement.Model;
using com.wuqiang.courseManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace com.wuqiang.courseManagement.View
{
    /// <summary>
    /// CoursePageView.xaml 的交互逻辑
    /// </summary>
    public partial class CoursePageView : UserControl
    {
        public CoursePageView()
        {
            InitializeComponent();
            this.DataContext = new CoursePageViewModel();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            string content = radioButton.Content.ToString();

            ICollectionView view = CollectionViewSource.GetDefaultView(this.icCourses.ItemsSource);
            if (content=="全部")
            {
                view.Filter = null;

                //排序 Descending 降序    Ascending 升序
                view.SortDescriptions.Add(new SortDescription("CourseName", ListSortDirection.Descending));
            }
            else
            {
                view.Filter = new Predicate<object>(p => {
                    return (p as CourseModel).Teachers.Exists(t => t == content);
                });
            }
        }
    }
}
