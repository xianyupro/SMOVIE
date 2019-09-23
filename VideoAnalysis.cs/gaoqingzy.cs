using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoAnalysis.Common;

namespace VideoAnalysis.cs
{
    class gaoqingzy
    {
        private string SeachName = "";
        public gaoqingzy(String seachName)
        {
            SeachName = seachName;
            

            //string QQMusictxt = response.GetText();
            //JObject QQMusicJson = response.ConvertJson(QQMusictxt.Substring(9, QQMusictxt.Length - 10));
            //foreach (var Song in QQMusicJson["data"]["song"]["list"])
            //{
            //    MusicName.Add(Song["songname"].ToString());
            //    SingerName.Add(Song["singer"][0]["name"].ToString());
            //    MediaID.Add(Song["media_mid"].ToString());
            //    MediaTime.Add((Convert.ToInt16(Song["interval"].ToString()) / 60).ToString() + ":" + (Convert.ToInt16(Song["interval"].ToString()) % 60).ToString());
            //    album_name.Add(Song["albumname"].ToString());
            //}
            //Console.WriteLine(MusicName);
        }
        public List<string[]> GetMovieList()
        {
            List<string[]> MovieInfo = new List<string[]>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Timeout", "2000");
            headers.Add("ContentType", "application/x-www-form-urlencoded; charset=UTF-8");
            headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");

            Request Response_MoviePage = new Request("http://www.gaoqingzy.com/index.php?m=vod-search&wd=" + "奇异博士", headers);
            var html = Response_MoviePage.GetHtml();
            foreach (var MovieUrl_A in html[0].SelectNodes("//ul[@class='nr']"))
            {
                String MovieUrl = "http://www.gaoqingzy.com" + MovieUrl_A.SelectSingleNode(".//a[@class='name']").Attributes["href"].Value;
                Request Response_MovieUrl = new Request(MovieUrl, headers);
                var html_MovieUrl = Response_MovieUrl.GetHtml()[0];
                string MovieName = html_MovieUrl.SelectSingleNode("//div[@class='vodInfo']//h2[1]").InnerText;
                //这里的标签页从第一行开始
                //var x = html_MovieUrl.SelectSingleNode("//div[@class='vodplayinfo'][1]").InnerText;
                Console.WriteLine(MovieName);
                foreach (var f3 in html_MovieUrl.SelectSingleNode("//div[@style='padding-left:10px;word-break: break-all; word-wrap:break-word;']").SelectNodes(".//li"))
                {
                    int index = f3.InnerText.IndexOf("$");
                    string MovieAddress = f3.InnerText.Substring(index + 1, f3.InnerText.Length - index - 1);
                    Console.WriteLine(MovieAddress);
                    MovieInfo.Add(new string[2] { MovieName, MovieAddress });
                }
            }
            return MovieInfo;
        }
    }
}
