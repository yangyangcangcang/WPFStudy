using BootstrapperShell_01.Views;
using Prism.Ioc;
using Prism.Regions;
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

namespace BootstrapperShell_01
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private  readonly IRegionManager _RegionManager = null;
        private readonly IContainerExtension _ContainerExtension = null;

        private UserControlA _UserControlA;
        private UserControlB _UserControlB;
        IRegion _Region = null;
        public MainWindow(IContainerExtension containerExtension, IRegionManager  regionManager)
        {

            InitializeComponent();
            _RegionManager = regionManager;
            _ContainerExtension = containerExtension;

            this.Loaded += MainWindow_Loaded;
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(UserControlA));
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this._UserControlA = _ContainerExtension.Resolve<UserControlA>();
            this._UserControlB = _ContainerExtension.Resolve<UserControlB>();
            _Region = _RegionManager.Regions["ContentRegion"];

            _Region.Add(_UserControlA);
            _Region.Add(_UserControlB);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControlA userControlA =  _ContainerExtension.Resolve<UserControlA>();
            IRegion region =  _RegionManager.Regions["ContentRegion"];
            region.Add(userControlA);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _Region.Activate(this._UserControlA);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _Region.Deactivate(this._UserControlA);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _Region.Activate(this._UserControlB);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _Region.Deactivate(this._UserControlB);
        }
    }
}
