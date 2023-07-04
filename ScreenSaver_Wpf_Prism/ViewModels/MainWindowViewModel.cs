using Prism.Commands;
using Prism.Mvvm;
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

        public MainWindowViewModel()
        {
            EscCommand = new DelegateCommand(EscKeyDown);
        }

        private void EscKeyDown()
        {
            Application.Current.Shutdown();
        }

        private void OnStart()
        {
            
        }
    }
}
