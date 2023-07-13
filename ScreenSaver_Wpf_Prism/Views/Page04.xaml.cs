using Microsoft.Web.WebView2.WinForms;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenSaver_Wpf_Prism.Views
{
    /// <summary>
    /// Interaction logic for Page04.xaml
    /// </summary>
    public partial class Page04 : UserControl
    {
        public Page04()
        {
            InitializeComponent();
            Run();
        }

        public async Task Run()
        {
            await WV1.EnsureCoreWebView2Async();
            WV1.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            WV1.CoreWebView2.Navigate(HtmlHelper.BOC_CnToAu);
            WV1.NavigationCompleted += (sender, e) =>
            {
                if (e.IsSuccess)
                {
                    ((Microsoft.Web.WebView2.Wpf.WebView2)sender).ExecuteScriptAsync("document.querySelector('body').style.overflow='hidden'");
                }
            };

            await WV2.EnsureCoreWebView2Async();
            WV2.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            WV2.CoreWebView2.NavigateToString(HtmlHelper.Clock_Digital);
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
