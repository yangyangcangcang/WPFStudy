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

namespace WpfApplicationItemTemplate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //List<Color> colorList = new List<Color>();
            //colorList.Add(new Color() { Code = "#FF8C00" });
            //colorList.Add(new Color() { Code = "#FF7F50" });
            //colorList.Add(new Color() { Code = "#FF6EB4" });
            //colorList.Add(new Color() { Code = "#FF4500" });
            //colorList.Add(new Color() { Code = "#FF3030" });
            //colorList.Add(new Color() { Code = "#CD5B45" });
            //this.listBox.ItemsSource = colorList;
            //this.cob.ItemsSource = colorList;

            List<Test> testList = new List<Test>();
            testList.Add(new Test() { Code="1"});
            testList.Add(new Test() { Code = "2" });
            testList.Add(new Test() { Code = "3" });
            testList.Add(new Test() { Code = "4" });
            this.IC.ItemsSource = testList;
        }
    }
    public class Test
    {
        public string Code { get; set; }
    }


    public class Color
    {
        public string Code { get; set; }
    }


}
