using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ScreenSaver_Wpf_Prism.Helpers;
using ScreenSaver_Wpf_Prism.Models;
using ScreenSaver_Wpf_Prism.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ScreenSaver_Wpf_Prism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public event Action PageChanged;
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
            //LeftCommand = new DelegateCommand(LeftKeyDown);
            //RightCommand = new DelegateCommand(RightKeyDown);
            OnStart();
        }

        private void EscKeyDown()
        {
            Application.Current.Shutdown();
        }

        //private void LeftKeyDown()
        //{
        //    Debug.WriteLine("Left");
        //    _regionManager.RequestNavigate("PageRegion", nameof(Page01));
        //}
        //private void RightKeyDown()
        //{
        //    Debug.WriteLine("Right");
        //    _regionManager.RequestNavigate("PageRegion", nameof(Page02));
        //}


        private async Task OnStart()
        {
            await ChangeTheRegionPage();
        }

        /// <summary>
        /// 不断的轮询，更换Page
        /// </summary>
        /// <returns></returns>
        private async Task ChangeTheRegionPage()
        {
            List<PageConfigModel> pageConfigModels = Helper.GetPageConfigModels();
            while (true)
            {
                foreach (PageConfigModel model in pageConfigModels)
                {
                    _regionManager.RequestNavigate("PageRegion", model.PageName);
                    Task.Run(async () =>
                    {
                        await Task.Delay(model.PageTime * 1000 - Helper.GetAnimationMillisecond());
                        PageChanged?.Invoke();
                        Debug.WriteLine("Invoke=" + DateTime.Now);
                    });
                    await Task.Delay(model.PageTime * 1000);
                    //PageChanged?.Invoke();
                    Debug.WriteLine("Change=" + DateTime.Now);
                }
            }
        }

    }
}
