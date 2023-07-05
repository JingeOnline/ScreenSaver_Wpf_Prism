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
            //return null;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Page1>();
            containerRegistry.RegisterForNavigation<Page2>();
        }

        /// <summary>
        /// Startup different window depending on what parameter be passed in. (Example: App.exe Hello, Hello will be passed in.)
        /// </summary>
        /// <param name="e">Program startup parameter.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //if (e.Args.Length == 1)
            //{
            //    startup_window = "SettingWindow";
            //}
            //else
            //{
            //    startup_window = "MainWindow";
            //}
            _startupEventArgs = e;
            base.OnStartup(e);
        }

        protected override void OnInitialized()
        {
            //获得RegionManager实例
            IRegionManager regionManager = Container.Resolve<IRegionManager>();
            //指定程序启动后Region中默认注入的内容。指定Region的名称，和要填充的View的
            regionManager.RegisterViewWithRegion("PageRegion", typeof(Page1));

            base.OnInitialized();
        }
    }
}
