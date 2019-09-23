using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VideoAnalysis.Common
{
    public class Request : IDisposable
    {
        private HttpWebRequest HttpWReq;

        public bool StatusCode = false;


        public Request(string url)
        {
            HttpWReq = (HttpWebRequest)WebRequest.Create(url);

        }
        public Request(string url, Dictionary<string, string> Headers)
        {
            HttpWReq = (HttpWebRequest)WebRequest.Create(url);

            if (Headers.ContainsKey("Timeout"))
            {
                HttpWReq.Timeout = Convert.ToInt16(Headers["Timeout"]);
            }
            if (Headers.ContainsKey("ContentType"))
            {
                HttpWReq.ContentType = Headers["ContentType"];
            }
            if (Headers.ContainsKey("Cookie"))
            {
                HttpWReq.Headers.Add("Cookie", Headers["Cookie"]);
            }
            if (Headers.ContainsKey("UserAgent"))
            {
                HttpWReq.UserAgent = Headers["UserAgent"];
            }
            if (Headers.ContainsKey("Host"))
            {
                HttpWReq.Host = Headers["Host"];
            }
            if (Headers.ContainsKey("Accept"))
            {
                HttpWReq.Accept = Headers["Accept"];
            }
        }

        public string GetText()
        {
            HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
            StreamReader sr = new StreamReader(HttpWResp.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            string retString = sr.ReadToEnd();
            StatusCode = HttpWResp.StatusCode == HttpStatusCode.OK;
            return retString;
        }

        public Stream GetContent()
        {
            HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
            var content = HttpWResp.GetResponseStream();
            StatusCode = HttpWResp.StatusCode == HttpStatusCode.OK;
            return content;
        }

        public bool SaveContent(string path, Stream content)
        {
            try
            {
                using (FileStream fl = new FileStream(path, FileMode.Create))//展开一个流
                {
                    content.CopyTo(fl);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        /// <summary>
        /// 一个实例只能调用一次
        /// </summary>
        /// <returns></returns>
        public HtmlNodeCollection GetHtml()
        {
            HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
            StatusCode = HttpWResp.StatusCode == HttpStatusCode.OK;
            StreamReader sr = new StreamReader(HttpWResp.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            HtmlDocument doc = new HtmlDocument();
            doc.Load(sr);
            HtmlNodeCollection ulNodes = doc.DocumentNode.ChildNodes;
            return ulNodes;
        }

        private HtmlNodeCollection Getelement(HtmlDocument html)
        {
            HtmlNodeCollection ulNodes = html.DocumentNode.SelectSingleNode("//div[@id='pane-news']").SelectNodes("ul");
            //注意路径里"//"表示从根节点开始查找，两个斜杠‘//’表示查找所有childnodes；一个斜杠'/'表示只查找第一层的childnodes（即不查找grandchild）；点斜杠"./"表示从当前结点而不是根结点开始查找。
            //HtmlNode IDNode = doc.DocumentNode.SelectSingleNode("//div[@id='header']/div[@id='blogTitle']/h1");
            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(url)//博客主页URL
            //下面的意思是：通过属性id的值，来定位header下的blogTitle节点信息
            //HtmlNode titleNode = doc.DocumentNode.SelectSingleNode("//div[@id='header']/div[@id='blogTitle']");
            //if (ulNodes != null && ulNodes.Count > 0)
            //{
            //    for (int i = 0; i < ulNodes.Count; i++)
            //    {
            //        HtmlNodeCollection liNodes = ulNodes[i].SelectNodes("li");
            //        for (int j = 0; j < liNodes.Count; j++)
            //        {
            //            string title = liNodes[j].SelectSingleNode("a").InnerHtml.Trim();
            //            string href = liNodes[j].SelectSingleNode("a").GetAttributeValue("href", "").Trim();
            //            Console.WriteLine("新闻标题：" + title + ",链接：" + href);
            //        }
            //    }
            //}
            //string name = htmlDoc.DocumentNode
            //            .SelectNodes("//td/input")
            //            .First()
            //            .Attributes["value"].Value;

            //1 //我们获取博客ID
            //2 IDNode.OuterHtml ///返回结果是：<h1><a id="Header1_HeaderTitle" class="headermaintitle" href="http://www.cnblogs.com/xuliangxing/">法号阿兴</a></h1>
            //3 IDNode.InnerHtml ///返回结果是：<a id="Header1_HeaderTitle" class="headermaintitle" href="http://www.cnblogs.com/xuliangxing/">法号阿兴</a>
            //4 IDNode.InnerText ///返回结果是：法号阿兴

            //string url = doc.DocumentNode.SelectSingleNode("//div[@id='header']/div[@id='blogTitle']/a").Attributes["href"].Value;
            return ulNodes;
        }

        public JObject GetJson()
        {
            HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();
            StatusCode = HttpWResp.StatusCode == HttpStatusCode.OK;
            StreamReader sr1 = new StreamReader(HttpWResp.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
            string retString = sr1.ReadToEnd();
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(retString);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);

                return JsonConvert.DeserializeObject<JObject>(textWriter.ToString());
            }
            else
            {
                return null;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~Request() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
