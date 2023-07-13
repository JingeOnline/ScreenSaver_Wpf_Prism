using Microsoft.Web.WebView2.Wpf;
using ScreenSaver_Wpf_Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenSaver_Wpf_Prism.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page01 : UserControl
    {
         

        public Page01()
        {
            InitializeComponent();
            Run();
        }

        public async Task Run()
        {
            WebView2 WV1 = new WebView2();
            Grid_Root.Children.Add(WV1);
            WV1.ZoomFactor = 1;
            WV1.Height = 720;
            WV1.Width = 720;
            WV1.HorizontalAlignment = HorizontalAlignment.Left;
            WV1.VerticalAlignment = VerticalAlignment.Top;
            WV1.Margin=new Thickness(140,100,0,0);

            await WV1.EnsureCoreWebView2Async();
            WV1.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            WV1.NavigateToString(HtmlHelper.Clock_Round);


            WebView2 WV2 = new WebView2();
            Grid_Root.Children.Add(WV2);
            WV2.ZoomFactor = 1.5;
            WV2.Height = 200;
            WV2.Width = 1700;
            WV2.HorizontalAlignment = HorizontalAlignment.Center;
            WV2.VerticalAlignment = VerticalAlignment.Bottom;
            WV2.Margin = new Thickness(0, 0, 0, 40);

            await WV2.EnsureCoreWebView2Async();
            WV2.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            WV2.NavigateToString(HtmlHelper.Weather_Week);

            WebView2 WV3 = new WebView2();
            Grid_Root.Children.Add(WV3);
            WV3.ZoomFactor = 1.2;
            WV3.Height = 830;
            WV3.Width = 660;
            WV3.HorizontalAlignment = HorizontalAlignment.Right;
            WV3.VerticalAlignment = VerticalAlignment.Top;
            WV3.Margin = new Thickness(0, 110, 160, 20);

            await WV3.EnsureCoreWebView2Async();
            WV3.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            WV3.CoreWebView2.NavigateToString(HtmlHelper.Weather_Hours);
            WV3.NavigationCompleted += (sender, e) =>
            {
                if (e.IsSuccess)
                {
                    ((Microsoft.Web.WebView2.Wpf.WebView2)sender).ExecuteScriptAsync("document.querySelector('body').style.overflow='hidden'");
                }
            };
        }

    }
}
