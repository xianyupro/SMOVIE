using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoAnalysis.Common;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject spyuan = JsonHelper.Readjson(@"D:\坚果云\技术文档与学习\现阶段好玩的\Movie.json");
            List<string[]> MovieInfo = new List<string[]>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Timeout", "2000");
            headers.Add("ContentType", "application/x-www-form-urlencoded; charset=UTF-8");
            headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");

            //Request Response_MoviePage = new Request("http://www.gaoqingzy.com/index.php?m=vod-search&wd=" + "奇异博士", headers);
            //var html = Response_MoviePage.GetHtml();
            //foreach (var MovieUrl_A in html[0].SelectNodes("//ul[@class='nr']"))
            //{
            //    String MovieUrl = "http://www.gaoqingzy.com" + MovieUrl_A.SelectSingleNode(".//a[@class='name']").Attributes["href"].Value;
            //    Request Response_MovieUrl = new Request(MovieUrl, headers);
            //    var html_MovieUrl = Response_MovieUrl.GetHtml()[0];
            //    string MovieName = html_MovieUrl.SelectSingleNode("//div[@class='vodInfo']//h2[1]").InnerText;
            //    //这里的标签页从第一行开始
            //    //var x = html_MovieUrl.SelectSingleNode("//div[@class='vodplayinfo'][1]").InnerText;
            //    Console.WriteLine(MovieName);
            //    foreach (var f3 in html_MovieUrl.SelectSingleNode("//div[@style='padding-left:10px;word-break: break-all; word-wrap:break-word;']").SelectNodes(".//li"))
            //    {
            //        int index = f3.InnerText.IndexOf("$");
            //        string MovieAddress = f3.InnerText.Substring(index + 1, f3.InnerText.Length - index - 1);
            //        Console.WriteLine(MovieAddress);
            //        MovieInfo.Add(new string[2] { MovieName, MovieAddress });
            //    }
            //}
            foreach(var MovieFindKey in spyuan["Movie"])
            {
                Request Response_MoviePage = new Request(MovieFindKey["searchUrl"] + "流浪地球", headers);
                var html = Response_MoviePage.GetHtml();
                var PageMS = html[0].SelectNodes(MovieFindKey["PageListFind"]["PageList"].ToString());
                if (PageMS == null)
                {
                    Console.WriteLine(MovieFindKey["title"] + "无该资源"); continue;
                }
                foreach (var MovieUrl_A in PageMS)
                {
                    String MovieUrl = MovieFindKey["baseUrl"] + MovieUrl_A.SelectSingleNode(MovieFindKey["PageListFind"]["MovieAdress"].ToString()).Attributes[MovieFindKey["PageListFind"]["href"].ToString()].Value;
                    Request Response_MovieUrl = new Request(MovieUrl, headers);
                    var html_MovieUrl = Response_MovieUrl.GetHtml()[0];
                    string MovieName = html_MovieUrl.SelectSingleNode(MovieFindKey["MovieNmae"].ToString()).InnerText;
                    //这里的标签页从第一行开始
                    //var x = html_MovieUrl.SelectSingleNode("//div[@class='vodplayinfo'][1]").InnerText;
                    Console.WriteLine(MovieName);
                    foreach (var f3 in html_MovieUrl.SelectSingleNode(MovieFindKey["MovieListFind"]["MovieList"].ToString()).SelectNodes(MovieFindKey["MovieListFind"]["MovieUrl"].ToString()))
                    {
                        int index = f3.InnerText.IndexOf("$");
                        if (index == -1) { continue; }
                        string MovieAddress = f3.InnerText.Substring(index + 1, f3.InnerText.Length - index - 1);
                        Console.WriteLine(MovieFindKey["title"]+"- - - - - -"+MovieAddress);
                        MovieInfo.Add(new string[2] { MovieName, MovieAddress });
                    }
                }
            }
            Console.WriteLine("查找结束，点击退出");
            Console.ReadKey();
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
    }
}
