using Prism.Ioc;
using Prism.Regions;
using ScreenSaver_Wpf_Prism.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ScreenSaver_Wpf_Prism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private StartupEventArgs _startupEventArgs;
        protected override Window CreateShell()
        {
            if (_startupEventArgs.Args.Length == 1)
            {
                return Container.Resolve<SettingWindow>();
            }
            else
            {
                return Container.Resolve<MainWindow>();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Page01>();
            containerRegistry.RegisterForNavigation<Page02>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _startupEventArgs = e;
            base.OnStartup(e);
        }

        protected override void OnInitialized()
        {
            //获得RegionManager实例
            IRegionManager regionManager = Container.Resolve<IRegionManager>();
            //指定程序启动后Region中默认注入的内容。
            regionManager.RegisterViewWithRegion("PageRegion", typeof(Page01));

            base.OnInitialized();
        }
    }
}
