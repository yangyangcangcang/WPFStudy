using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using ViewModelLocator_03.ViewModels;
using ViewModelLocator_03.Views;

namespace ViewModelLocator_03
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }


        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            //** 不同路径的绑定
            //ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(x => {

            //   string viewName =  x.FullName;
            //    string viewAssemblyName =  x.GetTypeInfo().Assembly.FullName;
            //    string viewModelName = $"{viewName}ViewModel,{viewAssemblyName}";

            //    return Type.GetType(viewModelName);
            //});
            // type / type
            //ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), typeof(CustomViewModel));

            // type / factory
            ViewModelLocationProvider.Register(typeof(MainWindow).ToString(), () => Container.Resolve<CustomViewModel>());

            // generic factory
            //ViewModelLocationProvider.Register<MainWindow>(() => Container.Resolve<CustomViewModel>());

            // generic type
            //ViewModelLocationProvider.Register<MainWindow, CustomViewModel>();


        }


    }
}
