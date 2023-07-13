using ScreenSaver_Wpf_Prism.Helpers;
using ScreenSaver_Wpf_Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenSaver_Wpf_Prism.Views
{
    /// <summary>
    /// Interaction logic for Page03.xaml
    /// </summary>
    public partial class Page03 : UserControl
    {
        public Page03()
        {
            InitializeComponent();
            Run();
        }

        public async Task Run()
        {
            YouTubeService youTubeService = new YouTubeService();
            await WV1.EnsureCoreWebView2Async();
            WV1.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            string url=await youTubeService.GetRandomVideoEmbedUrl();
            Debug.WriteLine(url);
            //WV1.CoreWebView2.Navigate(HtmlHelper.Youtube_4K_Url);
            WV1.CoreWebView2.Navigate(url);

        }
    }
}
