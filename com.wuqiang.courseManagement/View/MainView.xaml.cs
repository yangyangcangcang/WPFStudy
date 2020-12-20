using com.wuqiang.courseManagement.ViewModel;
using System;
using System.Collections.Generic;
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
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            //防止把状态栏  遮住
            this.MaxHeight = SystemParameters.PrimaryScreenHeight;

            this.DataContext = new MainViewModel();

        }

        /// <summary>
        /// 移动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton ==MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }



        #region 窗口最小化
        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion

        private void ButtonMax_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized?WindowState.Normal: WindowState.Maximized;
        }

        private void ButtonFrmClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
