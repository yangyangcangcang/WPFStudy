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

namespace WpfApplication5
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //txt.DataContext = new Message() { Content = "www"};
            this.DataContext = new MainViewModel();
        }

        //private void sd_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    this.txt.Text = this.sd.Value.ToString() ;
        //}
    }
    public class Message
    {
        public string Content { get; set; }
    }
}
