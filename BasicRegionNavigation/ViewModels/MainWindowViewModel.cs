using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRegionNavigation.ViewModels
{
    public class MainWindowViewModel:BindableBase
    {
        private readonly IRegionManager _RegionManager;

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MainWindowViewModel(IRegionManager  regionManager)
        {
            this._RegionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(x => {

                if (!string.IsNullOrEmpty(x))
                {
                    _RegionManager.RequestNavigate("ContentRegion", x, NavigationComplete);
                }
            
            });
        }

        private void NavigationComplete(NavigationResult result)
        {
            //System.Windows.MessageBox.Show(String.Format("Navigation to {0} complete. ", result.Context.Uri));
        }
    }
}
