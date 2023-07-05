using ScreenSaver_Wpf_Prism.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaver_Wpf_Prism
{
    public class Helper
    {
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
    }
}
