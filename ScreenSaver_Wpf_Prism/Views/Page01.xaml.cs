﻿using ScreenSaver_Wpf_Prism.Helpers;
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
            await WV1.EnsureCoreWebView2Async();
            WV1.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            WV1.NavigateToString(HtmlHelper.Clock_Round);
            await WV2.EnsureCoreWebView2Async();
            WV2.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            WV2.NavigateToString(HtmlHelper.Weather_Week);
        }

    }
}
