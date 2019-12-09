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

            Request Response_MoviePage = new Request("https://movie.douban.com/ithil_j/activity/movie_annual2018/widget/1", headers);
            JObject json = Response_MoviePage.GetJson();
            var x = json["res"]["subjects"][0]["title"].ToString();


           
            Console.WriteLine("查找结束，点击退出");
            Console.ReadKey();
          
        }
    }
}
