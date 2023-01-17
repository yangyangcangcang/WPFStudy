using ModuleCommandsA.ViewModels;
using ModuleCommandsA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCommandsA
{
    public class ModuleAModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            IRegion region = regionManager.Regions["ContentRegion"];

            TabView tabViewA =  containerProvider.Resolve<TabView>();
            SetTitle(tabViewA, "Tab A");
            region.Add(tabViewA);

            TabView tabViewB = containerProvider.Resolve<TabView>();
            SetTitle(tabViewB, "Tab B");
            region.Add(tabViewB);

            TabView tabViewC = containerProvider.Resolve<TabView>();
            SetTitle(tabViewC, "Tab B");
            region.Add(tabViewC);

        }

        private void SetTitle(TabView tabView, string title)
        {
            (tabView.DataContext as TabViewModel).Title = title;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
           
        }
    }
}
