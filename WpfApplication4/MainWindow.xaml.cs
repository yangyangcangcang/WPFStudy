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

namespace WpfApplication4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //List<Color> list = new List<Color>();
            //list.Add(new Color() { Code = "#FF8C00" });
            //list.Add(new Color() { Code = "#FF7F50" });
            //list.Add(new Color() { Code = "#FF6E84" });
            //list.Add(new Color() { Code = "#FF3030" });
            //cob.ItemsSource = list;
            //lib.ItemsSource = list;
            List<Dome> list = new List<Dome>();
            list.Add(new Dome() { Code = "1" });
            list.Add(new Dome() { Code = "2" });
            list.Add(new Dome() { Code = "3" });
            list.Add(new Dome() { Code = "4" });
            ic.ItemsSource = list;
        }
    }

    public class Color
    {
        public string Code { get; set; }
    }

    public class Dome
    {
        public string Code { get; set; }
    }

}
