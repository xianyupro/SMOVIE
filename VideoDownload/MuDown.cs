using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoDownload
{
    public partial class MuDown : MaterialSkin.Controls.MaterialForm
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


        private string fileSaveLocation = "";
        private string Command = "";
        private int ffmpegid = 0;
        public delegate void DelReadStdOutput(string result);
        public delegate void DelReadErrOutput(string result);
        public event DelReadStdOutput ReadStdOutput;
        public event DelReadErrOutput ReadErrOutput;
        private bool DownloadFlag = false;
        private string CmdProcessName = "";
        private string videoName = "";
        private string VideoALLtime, DownloadPart, Videoinfo_D, ffmpegOutput;
        private int xianchen = 4;

        public MuDown()
        {
            InitializeComponent();
            ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);
            ReadErrOutput += new DelReadErrOutput(ReadErrOutputAction);
            VideoUrlText.Text = MuShow.url;
            fileNameText.Text = MuShow.name;
        }

        private void FileSaveLocationButt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdilog = new FolderBrowserDialog();
            fdilog.Description = "请选择文件夹";
            if (fdilog.ShowDialog() == DialogResult.OK )
            {
                fileSaveLocation = fdilog.SelectedPath;
            }
            else { fileSaveLocation = @"D:\"; }
            fileStext.Text = fileSaveLocation;
        }

        private void VideoStartD_Click(object sender, EventArgs e)
        {
            textBox_Info.Text = "";
            VideoInfo.Text = "- - -";
            if (!DownloadFlag)
            {
                if (MP4Radio.Checked == true)
                {
                    Command = "-threads "+ XianChengText.Text + " -i " + "\"" + VideoUrlText.Text + "\"" + " -c copy -y -bsf:a aac_adtstoasc " + "\"" + fileStext.Text + "\\" + fileNameText.Text + ".mp4" + "\"";
                    videoName = fileNameText.Text + ".mp4";
                    RealAction("Tools\\ffmpeg.exe", Command);
                }
                if (MKVRadio.Checked == true)
                {
                    Command = "-threads " + XianChengText.Text + " -i " + "\"" + VideoUrlText.Text + "\"" + " -c copy -y -bsf:a aac_adtstoasc " + "\"" + fileStext.Text + "\\" + fileNameText.Text + ".mkv" + "\"";
                    videoName = fileNameText.Text + ".mkv";
                    RealAction("Tools\\ffmpeg.exe", Command);
                }
                if (TSRadio.Checked == true)
                {
                    Command = "-threads " + XianChengText.Text + " -i " + "\"" + VideoUrlText.Text + "\"" + " -c copy -y -f mpegts " + "\"" + fileStext.Text + "\\" + fileNameText.Text + ".ts" + "\"";
                    videoName = fileNameText.Text + ".ts";
                    RealAction("Tools\\ffmpeg.exe", Command);
                }
                if (FLVRadio.Checked == true)
                {
                    Command = "-threads " + XianChengText.Text + " -i " + "\"" + VideoUrlText.Text + "\"" + " -c copy -y -f f4v -bsf:a aac_adtstoasc " + "\"" + fileStext.Text + "\\" + fileNameText.Text + ".flv" + "\"";
                    videoName = fileNameText.Text + ".flv";
                    RealAction("Tools\\ffmpeg.exe", Command);
                }
                DownloadFlag = true;
                VideoStartD.Text = "停止下载";
            }
            else
            {
                DownloadFlag = false;
                VideoStartD.Text = "开始下载";
                Stop();
            }
            
            
        }
        private void RealAction(string StartFileName, string StartFileArg)
        {
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = StartFileName;      // 命令  
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
            ffmpegid = CmdProcess.Id;//获取ffmpeg.exe的进程ID
            CmdProcessName = CmdProcess.ProcessName;
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
            ffmpegOutput= ffmpegOutput +result + "\r\n";
            textBox_Info.AppendText(result + "\r\n");
        }

        private void ReadErrOutputAction(string result)
        {
            ffmpegOutput = ffmpegOutput + result + "\r\n";
            textBox_Info.AppendText(result + "\r\n");
            GetVideoInfo();
        }

        private void CmdProcess_Exited(object sender, EventArgs e)
        {
            try
            {
                BeginInvoke(new Action(() =>
                {
                    FlashWindow(this.Handle, true);
                }), null);
                VideoStartD.Text = "立即下载";
                DownloadFlag = false;
                textBox_Info.AppendText("视频下载完成...... \r\n");
            }
            catch { }
            
        }

        private void GetVideoInfo()
        {
            Double All=1, Progress=0, Downloaded=0;
            Regex regex = new Regex(@"(\d\d[.:]){3}\d\d", RegexOptions.Compiled | RegexOptions.Singleline);//取视频时长以及Time属性
            VideoALLtime = "[总时长：" + regex.Match(ffmpegOutput).Value + "]";
            var time = regex.Matches(ffmpegOutput);
            if (time.Count > 0)
            { DownloadPart = "[已下载：" + time.OfType<Match>().Last() + "]"; }
            Regex fps = new Regex(@"(\S+)\sfps", RegexOptions.Compiled | RegexOptions.Singleline);//取视频帧数
            Regex resolution = new Regex(@"\d{2,}x\d{2,}", RegexOptions.Compiled | RegexOptions.Singleline);//取视频分辨率
            Videoinfo_D = "[视频信息：" + resolution.Match(ffmpegOutput).Value + "，" + fps.Match(ffmpegOutput).Value + "]";
            if (time.Count > 0)
            {
                All = Convert.ToDouble(Convert.ToDouble(VideoALLtime.Substring(5, 2)) * 60 * 60 + Convert.ToDouble(VideoALLtime.Substring(8, 2)) * 60
                + Convert.ToDouble(VideoALLtime.Substring(11, 2)) + Convert.ToDouble(VideoALLtime.Substring(14, 2)) / 100);
                Downloaded = Convert.ToDouble(Convert.ToDouble(DownloadPart.Substring(5, 2)) * 60 * 60 + Convert.ToDouble(DownloadPart.Substring(8, 2)) * 60
                + Convert.ToDouble(DownloadPart.Substring(11, 2)) + Convert.ToDouble(DownloadPart.Substring(14, 2)) / 100);
                Progress = (Downloaded / All) * 100;
                if (Progress > 100)  //防止进度条超过百分之百
                {
                    Progress = 100;
                }
                VideoInfo.Text = videoName + " " + Videoinfo_D + " " + VideoALLtime + " " + DownloadPart+"  下载进度："+ Progress.ToString("f2")+"%";
            }
        }

        private void OpenSaveLocation_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(fileStext.Text);
            }
            catch { MessageBox.Show("文件夹不存在！"); }
            
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void XianChengText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                xianchen = Convert.ToInt32(XianChengText.Text);
                if (xianchen < 0 || xianchen > 12)
                {
                    MessageBox.Show("线程数应该在0~12之间！");
                    XianChengText.Text = "4";
                }
            }
            catch
            {
                MessageBox.Show("线程数为整数！");
                XianChengText.Text = "4";
            }
        }

        private void MuDown_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Process.GetProcessesByName("ffmpeg").Length != 0)
            {
                if (MessageBox.Show("已启动下载进程，是否后台继续下载", "请确认您的操作", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Hide();
                    e.Cancel = true;
                    this.notifyIcon1.Visible = true;
                    this.notifyIcon1.ShowBalloonTip(10, "Tip", "最小化到托盘", ToolTipIcon.Info);
                }
                else
                {
                    Stop();
                    e.Cancel = false;
                }
            }
        }

        public void Stop()
        {
            AttachConsole(ffmpegid);
            SetConsoleCtrlHandler(IntPtr.Zero, true);
            GenerateConsoleCtrlEvent(0, 0);
            FreeConsole();
            KillProcess(CmdProcessName);
        }
        private void KillProcess(string processName)
        {
            Process[] myproc = Process.GetProcesses();
            foreach (Process item in myproc)
            {
                if (item.Id == ffmpegid)
                {
                    item.Kill();
                }
            }
        }
    }
}
