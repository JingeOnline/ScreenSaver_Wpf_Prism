using Prism.Ioc;
using ScreenSaver_Wpf_Prism.Views;
using System;
using System.Windows;

namespace ScreenSaver_Wpf_Prism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            //return Container.Resolve<MainWindow>();
            return null;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        /// <summary>
        /// Startup different window depending on what parameter be passed in. (Example: App.exe Hello, Hello will be passed in.)
        /// </summary>
        /// <param name="e">Program startup parameter.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (e.Args.Length == 1)
            {
                InitializeShell(Container.Resolve<SettingWindow>());
            }
            else
            {
                InitializeShell(Container.Resolve<MainWindow>());
            }

            OnInitialized();
        }
    }
}
