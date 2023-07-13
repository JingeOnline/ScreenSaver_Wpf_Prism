using Newtonsoft.Json;
using ScreenSaver_Wpf_Prism.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaver_Wpf_Prism.Services
{
    public class YouTubeService
    {
        private const string _RequestURL = "https://www.googleapis.com/youtube/v3/search?part=snippet&channelId=UCLouLFhGb9e95qmtttAKN3w&maxResults=10&order=date&type=video&key=";
        private const string _embedVideoUrlBase1 = "https://www.youtube.com/embed/";
        private const string _embedVideoUrlBase2 = "?start=0&autoplay=1&loop=1&mute=1";
        private string _Url;
        private List<string> ChannelList = new List<string>()
        {
            "UCLouLFhGb9e95qmtttAKN3w", //Dolby Vision Demo 4K
            "UCq0OueAsdxH6b8nyAspwViw", //@paramountpictures
            "UCjmJDM5pRKbUlVIzDYYWb6g", //Warner Bros. Pictures
            "UC1Myj674wRVXB9I4c6Hm5zA", //AppleTv
            "UCWOA1ZGywLbqmigxE4Qlvuw", //Netflix
            "UC2-BeLxzUBSs0uSrmzWhJuQ", //20th Century Studios
        };



        public YouTubeService()
        {
            string apiKey=Helper.GetGooleApiKey();
            _Url = _RequestURL+apiKey;
        }

        public async Task<string> GetRandomVideoEmbedUrl()
        {
            YouTubeChannelResponse channel = await getChannelModel(_Url);
            int count=channel.items.Count;
            Random random = new Random();
            int index=random.Next(0, count-1);
            string videoId= channel.items[index].id.videoId;
            return _embedVideoUrlBase1 + videoId + _embedVideoUrlBase2;
        }

        private async Task<YouTubeChannelResponse> getChannelModel(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string response= await client.GetStringAsync(url);
                YouTubeChannelResponse channel = JsonConvert.DeserializeObject<YouTubeChannelResponse>(response);
                return channel;
            }
        }
    }
}
