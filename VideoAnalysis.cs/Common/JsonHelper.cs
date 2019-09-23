using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoAnalysis.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// 读取JSON文件
        /// </summary>
        /// <param name="key">JSON文件中的key值</param>
        /// <returns>JSON文件中的value值</returns>
        public static JObject Readjson(string jsonfile)
        {
            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonfile))
            {
                //string str =file.ReadToEnd();
                //return ConvertJson(str);
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    //var value = o[key].ToString();
                    return o;
                }
            }
        }

        public static JObject ConvertJson(string str)
        {
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
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
    }
}
