using MaterialSkin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoAnalysis.Common;

namespace VideoDownload
{
    public partial class MuShow : MaterialSkin.Controls.MaterialForm
    {
        List<string> MovieList = new List<string>();
        List<string> MovieNameList = new List<string>();
        public static string url = "", name;
        private string movieName;
        private int CountMovie = 0;

        Dictionary<string, string> headers = new Dictionary<string, string>();
        string S = "";
        public MuShow()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red400, Primary.Red300, Primary.Yellow200, Accent.LightBlue200, TextShade.WHITE);
            headers.Add("Timeout", "1000");
            headers.Add("ContentType", "application/x-www-form-urlencoded; charset=UTF-8");
            headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
            System.Reflection.Assembly asm = this.GetType().Assembly;
            name = this.GetType().Namespace + ".2018Movie.txt" + name;
            System.IO.Stream strm = asm.GetManifestResourceStream(name);
            using (System.IO.StreamReader file = new System.IO.StreamReader(strm))
            {
                S = file.ReadToEnd();
            }
        }
        private JObject getStringResource(string name)
        {
            System.Reflection.Assembly asm = this.GetType().Assembly;
            //在这个文件中列出的所有资源    
            //asm.GetManifestResourceNames()
            name = this.GetType().Namespace + "." + name;
            System.IO.Stream strm = asm.GetManifestResourceStream(name);

            using (System.IO.StreamReader file = new System.IO.StreamReader(strm))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject oj = (JObject)JToken.ReadFrom(reader);
                    return oj;
                }
            }
        }

        private void LoginDataBase(string MovieName)
        {
            movieName = MovieName;
            CountMovie = 0;
            textBox_Info.Text = "";
            MovieList.Clear();
            MovieNameList.Clear();
            //JObject spyuan = JsonHelper.Readjson(Application.StartupPath+@"\Movie.json");
            JObject spyuan = getStringResource("Movie.json");
            foreach (var MovieFindKey in spyuan["Movie"])
            {
                if (MovieNameList.Count() > 1000)
                {
                    break ;
                }
                Thread thread_SeachMovie = new Thread(new ThreadStart(delegate ()
                {
                    SMovie(MovieFindKey);
                }));
                thread_SeachMovie.Start();
            }
        }
        private void SMovie(JToken MovieFindKey)
        {
            try
            {
                
                Request Response_MoviePage = new Request(MovieFindKey["searchUrl"] + movieName, headers);
                var html = Response_MoviePage.GetHtml();
                var PageMS = html[0].SelectNodes(MovieFindKey["PageListFind"]["PageList"].ToString());
                if (PageMS == null)
                {
                    Console.WriteLine(MovieFindKey["title"] + "无该资源"); return;
                }
                foreach (var MovieUrl_A in PageMS)
                {
                    String MovieUrl = MovieFindKey["baseUrl"] + MovieUrl_A.SelectSingleNode(MovieFindKey["PageListFind"]["MovieAdress"].ToString()).Attributes[MovieFindKey["PageListFind"]["href"].ToString()].Value;
                    Request Response_MovieUrl = new Request(MovieUrl, headers);
                    var html_MovieUrl = Response_MovieUrl.GetHtml()[0];
                    string MovieName = html_MovieUrl.SelectSingleNode(MovieFindKey["MovieNmae"].ToString()).InnerText;
                    Console.WriteLine(MovieName);
                    foreach (var f3 in html_MovieUrl.SelectSingleNode(MovieFindKey["MovieListFind"]["MovieList"].ToString()).SelectNodes(MovieFindKey["MovieListFind"]["MovieUrl"].ToString()))
                    {
                        int index = f3.InnerText.IndexOf("$");
                        if (index == -1) { continue; }
                        string MovieAddress = f3.InnerText.Substring(index + 1, f3.InnerText.Length - index - 1);
                        Console.WriteLine(MovieFindKey["title"] + "- - - - - -" + MovieAddress);
                        //MovieInfo.Add(new string[2] { MovieName, MovieAddress });
                        MovieList.Add(MovieAddress);
                        MovieNameList.Add(MovieName);
                        BeginInvoke(new Action(() =>
                        {
                            textBox_Info.AppendText("●   编号：" + CountMovie++ + "     电影名：" + MovieName + "      地址：" + MovieAddress + "\r\n");
                            textBox_Info.Update();
                        }), null);
                        if (MovieNameList.Count() > 1000)
                        {
                            return;
                        }
                    }
                }
            }
            catch
            {
                BeginInvoke(new Action(() =>
                {
                    textBox_Info.AppendText("由于网络问题，暂无资源" + "\r\n");
                    textBox_Info.Update();
                }), null);
                Console.WriteLine("网络出错");
            }
            BeginInvoke(new Action(() =>
            {
                textBox_Info.AppendText("------" + MovieFindKey["title"] + ":资源查找结束------" + "\r\n");
            }), null);
        }

        private void VideoStartF_Click(object sender, EventArgs e)
        {
            LoginDataBase(VideoNameText.Text);
        }

        private void PlayMovieButt_Click(object sender, EventArgs e)
        {
            try
            {
                url = MovieList[Convert.ToInt32(MovieID.Text)];
            }catch
            {
                MessageBox.Show("填写视频序号越界，请重新填写！");
                return;
            }
            
            if(url.Substring(url.Length-4, 4)=="m3u8")
            {
                Process.Start(@"https://www.m3u8play.com/?play=" + url);
            }
            else
            {
                Process.Start(url);
            }
        }

        private void MovieID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    url = MovieList[Convert.ToInt32(MovieID.Text)];
                }
                catch
                {
                    MessageBox.Show("填写视频序号越界，请重新填写！");
                    return;
                }

                if (url.Substring(url.Length - 4, 4) == "m3u8")
                {
                    Process.Start(@"https://www.m3u8play.com/?play=" + url);
                }
                else
                {
                    Process.Start(url);
                }
            }
        }

        private void 推荐资源ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Info.Text = "";
            InitMovie();
        }

        private void 复制查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox_Info.SelectedText != "")
            {
                //Clipboard.SetDataObject(textBox_Info.SelectedText);
                VideoNameText.Text = textBox_Info.SelectedText;
                LoginDataBase(VideoNameText.Text);
            }
                    
        }

        private void VideoNameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginDataBase(VideoNameText.Text);
            }
        }

        private void MuShow_Load(object sender, EventArgs e)
        {
            InitMovie();
        }

        private void 清空目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Info.Text = "";
        }

        private void 刷新列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginDataBase(VideoNameText.Text);
        }

        private void VideoNameText_TextChanged(object sender, EventArgs e)
        {
            if (VideoNameText.Text == "")
            {
                textBox_Info.Text = "";
                InitMovie();
            }
        }

        private void InitMovie()
        {
            textBox_Info.AppendText("**********************资源推荐*******************\r\n");
            textBox_Info.AppendText("\r\n");
            Thread InitMovieT = new Thread(delegate () {
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Timeout", "2000");
                headers.Add("ContentType", "application/x-www-form-urlencoded; charset=UTF-8");
                headers.Add("UserAgent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
                Request Response_New = new Request("https://movie.douban.com/j/search_subjects?type=movie&tag=%E6%9C%80%E6%96%B0&page_limit=40&page_start=0" , headers);
                Request Response_Hot = new Request("https://movie.douban.com/j/search_subjects?type=movie&tag=%E7%83%AD%E9%97%A8&page_limit=40&page_start=0", headers);
                JObject json_New = Response_New.GetJson();
                JObject json_Hot = Response_Hot.GetJson();
                int Number = 0;
                BeginInvoke(new Action(() =>
                {
                    textBox_Info.AppendText("*******最新电影排行榜*******" + "\r\n");
                }), null);
                foreach (var Movie in json_New["subjects"])
                {
                    Number++;
                    if (Number == 5)
                    {
                        Number = 0;
                        BeginInvoke(new Action(() =>
                        {
                            textBox_Info.AppendText(Movie["title"].ToString() + "\r\n");
                        }), null);

                    }
                    else
                    {
                        BeginInvoke(new Action(() =>
                        {
                            textBox_Info.AppendText(Movie["title"].ToString() + "      ##     ");
                        }), null);

                    }
                }
                Number = 0;
                BeginInvoke(new Action(() =>
                {
                    textBox_Info.AppendText("\r\n");
                    textBox_Info.AppendText("*******最热电影排行榜*******" + "\r\n");
                }), null);
                foreach (var Movie in json_Hot["subjects"])
                {
                    Number++;
                    if (Number == 5)
                    {
                        Number = 0;
                        BeginInvoke(new Action(() =>
                        {
                            textBox_Info.AppendText(Movie["title"].ToString() + "\r\n");
                        }), null);

                    }
                    else
                    {
                        BeginInvoke(new Action(() =>
                        {
                            textBox_Info.AppendText(Movie["title"].ToString() + "      ##     ");
                        }), null);

                    }
                }
                BeginInvoke(new Action(() =>
                {
                    textBox_Info.AppendText("\r\n");
                    textBox_Info.AppendText(S);
                    textBox_Info.Update();
                    textBox_Info.Focus();//获取焦点
                    textBox_Info.Select(0, 0);//光标定位到文本最后
                    textBox_Info.ScrollToCaret();//滚动到光标处
                }), null);

            });
            InitMovieT.Start();

            
            //var Movie2018 = json["res"]["subjects"][0]["title"].ToString();
        }
    }
}
