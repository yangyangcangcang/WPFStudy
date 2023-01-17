using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRegionNavigationModuleA.ViewModels
{
    public class ViewBViewModel:BindableBase, INavigationAware
    {
        private string _title = "ViewB";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value);  }
        }

        private int _pageViews;

        public int PageViews
        {
            get { return _pageViews; }
            set { SetProperty(ref _pageViews, value); }
        }

        //当导航到实现者时调用
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViews++;
        }
        ///是否接受此导航请求
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        //当实现者被导航离开时调用
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
