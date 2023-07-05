using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ScreenSaver_Wpf_Prism.Views;
using System;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows;
using System.Windows.Input;

namespace ScreenSaver_Wpf_Prism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand EscCommand { get; set; }
        public DelegateCommand LeftCommand { get; set; }
        public DelegateCommand RightCommand { get; set; }

        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            EscCommand = new DelegateCommand(EscKeyDown);
            LeftCommand = new DelegateCommand(LeftKeyDown);
            RightCommand = new DelegateCommand(RightKeyDown);
        }

        private void EscKeyDown()
        {
            Application.Current.Shutdown();
        }
        private void LeftKeyDown()
        {
            Debug.WriteLine("Left");
            _regionManager.RequestNavigate("PageRegion", nameof(Page1));
        }
        private void RightKeyDown()
        {
            Debug.WriteLine("Right");
            _regionManager.RequestNavigate("PageRegion", nameof(Page2));
        }

        private void OnStart()
        {
            
        }
    }
}
