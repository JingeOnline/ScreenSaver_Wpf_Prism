using ScreenSaver_Wpf_Prism.Helpers;
using ScreenSaver_Wpf_Prism.ViewModels;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ScreenSaver_Wpf_Prism.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _AnimationMilisecond;
        private MainWindowViewModel _VM;
        public MainWindow()
        {

            Cursor = Cursors.None;
            SetCursorPos(10000, 10000);
            _AnimationMilisecond =Helper.GetAnimationMillisecond();
            InitializeComponent();
            _VM = this.DataContext as MainWindowViewModel;
            _VM.PageChanged += OnPageChanged;
        }


        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        private async void OnPageChanged()
        {
            //GoOutToLeft();
            GoOutFromBottom();
            await Task.Delay(_AnimationMilisecond);
            ComeInFromTop();
            //ComeInFromRight();
        }

        /// <summary>
        /// 从屏幕上部进入
        /// </summary>
        private void ComeInFromTop()
        {

            this.Dispatcher.Invoke(() =>
            {
                Storyboard sb = new Storyboard();
                ThicknessAnimation slideAnimation = new ThicknessAnimation
                {
                    Duration = new Duration(TimeSpan.FromMilliseconds(_AnimationMilisecond)),
                    From = new Thickness(0, -this.ActualHeight, 0, this.ActualHeight),
                    To = new Thickness(0),
                    DecelerationRatio = 0.9
                };
                Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                sb.Children.Add(slideAnimation);
                sb.Begin(Region_ContentControl);
            });
        }

        /// <summary>
        /// 从屏幕底部消失
        /// </summary>
        private void GoOutFromBottom()
        {

            this.Dispatcher.Invoke(() =>
            {
                Storyboard sb = new Storyboard();
                ThicknessAnimation slideAnimation = new ThicknessAnimation
                {
                    Duration = new Duration(TimeSpan.FromMilliseconds(_AnimationMilisecond)),
                    From = new Thickness(0),
                    To = new Thickness(0, this.ActualHeight, 0, -this.ActualHeight),
                    DecelerationRatio = 0.9
                };
                Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                sb.Children.Add(slideAnimation);
                sb.Begin(Region_ContentControl);
            });
        }

        /// <summary>
        /// 从屏幕右侧进入
        /// </summary>
        private void ComeInFromRight()
        {

            this.Dispatcher.Invoke(() =>
            {
                Storyboard sb = new Storyboard();
                ThicknessAnimation slideAnimation = new ThicknessAnimation
                {
                    Duration = new Duration(TimeSpan.FromMilliseconds(_AnimationMilisecond)),
                    From = new Thickness(this.ActualWidth, 0, -this.ActualWidth, 0),
                    To = new Thickness(0),
                    DecelerationRatio = 0.9
                };
                Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                sb.Children.Add(slideAnimation);
                sb.Begin(Region_ContentControl);
            });
        }

        /// <summary>
        /// 从屏幕左侧消失
        /// </summary>
        private void GoOutToLeft()
        {
            this.Dispatcher.Invoke(() =>
            {
                Storyboard sb = new Storyboard();
                ThicknessAnimation slideAnimation = new ThicknessAnimation
                {
                    Duration = new Duration(TimeSpan.FromMilliseconds(_AnimationMilisecond)),
                    From = new Thickness(0),
                    To = new Thickness(-this.ActualWidth, 0, this.ActualWidth, 0),
                    DecelerationRatio = 0.9
                };
                Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                sb.Children.Add(slideAnimation);
                sb.Begin(Region_ContentControl);
            });
        }
    }
}
