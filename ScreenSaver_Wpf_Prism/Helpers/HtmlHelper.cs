using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaver_Wpf_Prism.Helpers
{
    public static class HtmlHelper
    {
        public static readonly string Clock_Round = "<iframe src=\"https://free.timeanddate.com/clock/i8xa9g0h/n152/szw700/szh700/hoc444/hbw4/hfceee/cf100/hgr0/fdi76/mqc444/mql10/mqw4/mqd98/mhc444/mhl10/mhw4/mhd98/mmc444/mml10/mmw1/mmd98/hhl50/hhw6\" frameborder=\"0\" width=\"700\" height=\"700\"></iframe>\r\n";
        public static readonly string Weather_Week = "<a class=\"weatherwidget-io\" href=\"https://forecast7.com/zh/n38d15144d36/geelong/\" data-label_1=\"GEELONG\" data-label_2=\"WEATHER\" data-font=\"微软雅黑 (Microsoft Yahei)\" data-theme=\"dark\" data-accent=\"rgba(255, 255, 255, 0)\" >GEELONG WEATHER</a>\r\n<script>\r\n!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src='https://weatherwidget.io/js/widget.min.js';fjs.parentNode.insertBefore(js,fjs);}}(document,'script','weatherwidget-io-js');\r\n</script>";
        public static readonly string Outlook_Calendar_Url = "https://outlook.live.com/calendar/0/view/month";
        public static readonly string Outlook_Calendar_JS = "document.getElementById(\"o365header\").style.display='none';"
                + "document.getElementById(\"LeftRail\").style.display='none';"
                + "document.getElementsByClassName(\"UAnq8 QpyM8\")[0].style.display='none';"
                + "document.getElementsByClassName(\"I1FTF\")[0].style.display='none'";
        public static readonly string Youtube_4K_Url = "https://www.youtube.com/embed/kbGRmBlC3yA?start=15&autoplay=1&mute=1";
    }
}
