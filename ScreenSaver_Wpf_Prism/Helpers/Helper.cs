using ScreenSaver_Wpf_Prism.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScreenSaver_Wpf_Prism.Helpers
{
    public class Helper
    {
        #region 获取PageConfig.txt文件中的值
        private static string _FilePath = "PageConfig.txt";
        private static List<PageConfigModel> _PageConfigModels;

        public static List<PageConfigModel> GetPageConfigModels()
        {
            if (_PageConfigModels == null)
            {
                _PageConfigModels = new List<PageConfigModel>();
                string[] lines = File.ReadAllLines(_FilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    PageConfigModel model = new PageConfigModel();
                    model.PageName = parts[0];
                    model.PageTime = int.Parse(parts[1]);
                    _PageConfigModels.Add(model);
                }
            }
            return _PageConfigModels;
        }
        #endregion

        #region 获取Config文件中的值
        private static Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static int GetAnimationMillisecond()
        {
            return Int32.Parse(config.AppSettings.Settings["AnimationMillisecond"].Value);
        }
        public static string GetGooleApiKey()
        {
            try
            {
                string key = config.AppSettings.Settings["GoogleApiKey"].Value;
                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show("Please setup google api key in the config file.");
                }
                return key;
            }
            catch
            {
                MessageBox.Show("Please setup google api key in the config file.");
                return null;
            }
        }
        #endregion
    }
}
