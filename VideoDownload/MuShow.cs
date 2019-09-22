using MySql.Data.MySqlClient;
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

namespace VideoDownload
{
    public partial class MuShow : MaterialSkin.Controls.MaterialForm
    {
        [DllImport("kernel32.dll")]
        static extern bool GenerateConsoleCtrlEvent(int dwCtrlEvent, int dwProcessGroupId);
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(IntPtr handlerRoutine, bool add);
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        public delegate void DelReadStdOutput(string result);
        public delegate void DelReadErrOutput(string result);
        public event DelReadStdOutput ReadStdOutput;
        public event DelReadErrOutput ReadErrOutput;
        List<string> MovieList = new List<string>();
        List<string> MovieNameList = new List<string>();
        private string ffmpegOutput;
        private int FFplayid;
        public static string url = "", name;
        public MuShow()
        {
            InitializeComponent();
            ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);
            ReadErrOutput += new DelReadErrOutput(ReadErrOutputAction);
        }
        private void LoginDataBase(string MovieName)
        {
            textBox_Info.Text = "";
            MovieList.Clear();
            MovieNameList.Clear();
            string constructorString = "Database=doubanMovie;Data Source= 120.77.159.49;User Id=doubanMovie;Password=EwJSpRGRaMxLHHNc;charset='utf8';pooling=true";
            MySqlConnection myConnnect = new MySqlConnection(constructorString);
            myConnnect.Open();
            DataSet Movieds = new DataSet();
            string MovieInfo = "SELECT * FROM `MovieUrl` WHERE name LIKE '%" + MovieName + "%'";
            using (MySqlDataAdapter adp = new MySqlDataAdapter(MovieInfo, myConnnect))
            {
                adp.Fill(Movieds);
            }
            myConnnect.Close();
            for(int i = 0 ;i< Movieds.Tables[0].Rows.Count; i++)
            {
                textBox_Info.AppendText("编号："+i+"     电影名："+Movieds.Tables[0].Rows[i][1].ToString()+"      地址："+ Movieds.Tables[0].Rows[i][2].ToString() + "\r\n");
                MovieList.Add(Movieds.Tables[0].Rows[i][2].ToString());
                MovieNameList.Add(Movieds.Tables[0].Rows[i][1].ToString());
                Thread.Sleep(100);
            }
            Movieds.Dispose();
        }

        private void VideoStartF_Click(object sender, EventArgs e)
        {
            LoginDataBase(VideoNameText.Text);
        }
        private void OpenUseM3U8(string StartFileArg)
        {
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = @"Tools/ffplay.exe";      // 命令  
            CmdProcess.StartInfo.Arguments = StartFileArg;      // 参数  

            CmdProcess.StartInfo.CreateNoWindow = true;         // 不创建新窗口  
            CmdProcess.StartInfo.UseShellExecute = false;
            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入  
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出  
            CmdProcess.StartInfo.RedirectStandardError = true;  // 重定向错误输出  

            CmdProcess.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            CmdProcess.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            CmdProcess.EnableRaisingEvents = true;                      // 启用Exited事件  
            CmdProcess.Exited += new EventHandler(CmdProcess_Exited);   // 注册进程结束事件  

            CmdProcess.Start();
            FFplayid = CmdProcess.Id;
            CmdProcess.BeginOutputReadLine();
            CmdProcess.BeginErrorReadLine();
        }

        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.Invoke(ReadStdOutput, new object[] { e.Data });
            }
        }

        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.Invoke(ReadErrOutput, new object[] { e.Data });
            }
        }

        private void ReadStdOutputAction(string result)
        {
            ffmpegOutput = ffmpegOutput + result + "\r\n";
            textBox_Info.AppendText(result + "\r\n");
        }

        private void ReadErrOutputAction(string result)
        {
            ffmpegOutput = ffmpegOutput + result + "\r\n";
            textBox_Info.AppendText(result + "\r\n");
        }

        private void CmdProcess_Exited(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    FlashWindow(this.Handle, true);
                    LoginDataBase(VideoNameText.Text);
                }), null);
            }
            catch { }
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
                if (LocalPlayRadio.Checked)
                {
                    OpenUseM3U8(url);
                }
                else
                {
                    Process.Start(@"https://www.m3u8play.com/?play=" + url);
                }
            }
            else
            {
                Process.Start(url);
            }
        }

        private void DownloadM_Click(object sender, EventArgs e)
        {
            try
            {
                url = MovieList[Convert.ToInt32(MovieID.Text)];
                name= MovieNameList[Convert.ToInt32(MovieID.Text)];
            }
            catch
            {
                MessageBox.Show("填写视频序号越界，请重新填写！");
                return;
            }

            if (url.Substring(url.Length - 4, 4) == "m3u8")
            {
                MuDown muDown = new MuDown();
                muDown.Show();
            }
            else
            {
                MessageBox.Show("当前仅支持下载M3U8文件！");
            }
        }
    }
}
