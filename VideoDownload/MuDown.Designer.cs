namespace VideoDownload
{
    partial class MuDown
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MuDown));
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.VideoInfo = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.VideoUrlText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.fileStext = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.FileSaveLocationButt = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.MP4Radio = new MaterialSkin.Controls.MaterialRadioButton();
            this.FLVRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.MKVRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.TSRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.VideoStartD = new MaterialSkin.Controls.MaterialRaisedButton();
            this.OpenSaveLocation = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.fileNameText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.XianChengText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // textBox_Info
            // 
            this.textBox_Info.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox_Info.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Info.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_Info.Location = new System.Drawing.Point(11, 244);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.Size = new System.Drawing.Size(872, 387);
            this.textBox_Info.TabIndex = 0;
            this.textBox_Info.Text = "Video Information List here";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(14, 222);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(121, 19);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "视频信息显示：";
            // 
            // VideoInfo
            // 
            this.VideoInfo.AutoSize = true;
            this.VideoInfo.Depth = 0;
            this.VideoInfo.Font = new System.Drawing.Font("Roboto", 11F);
            this.VideoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.VideoInfo.Location = new System.Drawing.Point(128, 222);
            this.VideoInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.VideoInfo.Name = "VideoInfo";
            this.VideoInfo.Size = new System.Drawing.Size(29, 19);
            this.VideoInfo.TabIndex = 1;
            this.VideoInfo.Text = "- - -";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(12, 75);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(160, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "视频地址（M3U8）：";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(12, 106);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(89, 19);
            this.materialLabel4.TabIndex = 2;
            this.materialLabel4.Text = "保存路径：";
            // 
            // VideoUrlText
            // 
            this.VideoUrlText.Depth = 0;
            this.VideoUrlText.Hint = "";
            this.VideoUrlText.Location = new System.Drawing.Point(178, 75);
            this.VideoUrlText.MouseState = MaterialSkin.MouseState.HOVER;
            this.VideoUrlText.Name = "VideoUrlText";
            this.VideoUrlText.PasswordChar = '\0';
            this.VideoUrlText.SelectedText = "";
            this.VideoUrlText.SelectionLength = 0;
            this.VideoUrlText.SelectionStart = 0;
            this.VideoUrlText.Size = new System.Drawing.Size(705, 23);
            this.VideoUrlText.TabIndex = 3;
            this.VideoUrlText.Text = "https://youku.com-ok-pptv.com/20190920/7253_e7248787/index.m3u8";
            this.VideoUrlText.UseSystemPasswordChar = false;
            // 
            // fileStext
            // 
            this.fileStext.Depth = 0;
            this.fileStext.Hint = "";
            this.fileStext.Location = new System.Drawing.Point(100, 104);
            this.fileStext.MouseState = MaterialSkin.MouseState.HOVER;
            this.fileStext.Name = "fileStext";
            this.fileStext.PasswordChar = '\0';
            this.fileStext.SelectedText = "";
            this.fileStext.SelectionLength = 0;
            this.fileStext.SelectionStart = 0;
            this.fileStext.Size = new System.Drawing.Size(682, 23);
            this.fileStext.TabIndex = 3;
            this.fileStext.Text = "D:\\";
            this.fileStext.UseSystemPasswordChar = false;
            // 
            // FileSaveLocationButt
            // 
            this.FileSaveLocationButt.Depth = 0;
            this.FileSaveLocationButt.Location = new System.Drawing.Point(808, 104);
            this.FileSaveLocationButt.MouseState = MaterialSkin.MouseState.HOVER;
            this.FileSaveLocationButt.Name = "FileSaveLocationButt";
            this.FileSaveLocationButt.Primary = true;
            this.FileSaveLocationButt.Size = new System.Drawing.Size(75, 23);
            this.FileSaveLocationButt.TabIndex = 4;
            this.FileSaveLocationButt.Text = "保存位置";
            this.FileSaveLocationButt.UseVisualStyleBackColor = true;
            this.FileSaveLocationButt.Click += new System.EventHandler(this.FileSaveLocationButt_Click);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(316, 145);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(89, 19);
            this.materialLabel5.TabIndex = 2;
            this.materialLabel5.Text = "保存格式：";
            // 
            // MP4Radio
            // 
            this.MP4Radio.Checked = true;
            this.MP4Radio.Depth = 0;
            this.MP4Radio.Font = new System.Drawing.Font("Roboto", 10F);
            this.MP4Radio.Location = new System.Drawing.Point(402, 139);
            this.MP4Radio.Margin = new System.Windows.Forms.Padding(0);
            this.MP4Radio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.MP4Radio.MouseState = MaterialSkin.MouseState.HOVER;
            this.MP4Radio.Name = "MP4Radio";
            this.MP4Radio.Ripple = true;
            this.MP4Radio.Size = new System.Drawing.Size(75, 30);
            this.MP4Radio.TabIndex = 0;
            this.MP4Radio.TabStop = true;
            this.MP4Radio.Text = "MP4";
            this.MP4Radio.UseVisualStyleBackColor = true;
            // 
            // FLVRadio
            // 
            this.FLVRadio.Depth = 0;
            this.FLVRadio.Font = new System.Drawing.Font("Roboto", 10F);
            this.FLVRadio.Location = new System.Drawing.Point(472, 140);
            this.FLVRadio.Margin = new System.Windows.Forms.Padding(0);
            this.FLVRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.FLVRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.FLVRadio.Name = "FLVRadio";
            this.FLVRadio.Ripple = true;
            this.FLVRadio.Size = new System.Drawing.Size(75, 30);
            this.FLVRadio.TabIndex = 0;
            this.FLVRadio.Text = "FLV";
            this.FLVRadio.UseVisualStyleBackColor = true;
            // 
            // MKVRadio
            // 
            this.MKVRadio.Depth = 0;
            this.MKVRadio.Font = new System.Drawing.Font("Roboto", 10F);
            this.MKVRadio.Location = new System.Drawing.Point(536, 140);
            this.MKVRadio.Margin = new System.Windows.Forms.Padding(0);
            this.MKVRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.MKVRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.MKVRadio.Name = "MKVRadio";
            this.MKVRadio.Ripple = true;
            this.MKVRadio.Size = new System.Drawing.Size(75, 30);
            this.MKVRadio.TabIndex = 0;
            this.MKVRadio.Text = "MKV";
            this.MKVRadio.UseVisualStyleBackColor = true;
            // 
            // TSRadio
            // 
            this.TSRadio.Depth = 0;
            this.TSRadio.Font = new System.Drawing.Font("Roboto", 10F);
            this.TSRadio.Location = new System.Drawing.Point(607, 140);
            this.TSRadio.Margin = new System.Windows.Forms.Padding(0);
            this.TSRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.TSRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.TSRadio.Name = "TSRadio";
            this.TSRadio.Ripple = true;
            this.TSRadio.Size = new System.Drawing.Size(75, 30);
            this.TSRadio.TabIndex = 0;
            this.TSRadio.Text = "TS";
            this.TSRadio.UseVisualStyleBackColor = true;
            // 
            // VideoStartD
            // 
            this.VideoStartD.Depth = 0;
            this.VideoStartD.Font = new System.Drawing.Font("宋体", 12F);
            this.VideoStartD.Location = new System.Drawing.Point(18, 180);
            this.VideoStartD.MouseState = MaterialSkin.MouseState.HOVER;
            this.VideoStartD.Name = "VideoStartD";
            this.VideoStartD.Primary = true;
            this.VideoStartD.Size = new System.Drawing.Size(113, 34);
            this.VideoStartD.TabIndex = 5;
            this.VideoStartD.Text = "立即下载";
            this.VideoStartD.UseVisualStyleBackColor = true;
            this.VideoStartD.Click += new System.EventHandler(this.VideoStartD_Click);
            // 
            // OpenSaveLocation
            // 
            this.OpenSaveLocation.Depth = 0;
            this.OpenSaveLocation.Font = new System.Drawing.Font("宋体", 12F);
            this.OpenSaveLocation.Location = new System.Drawing.Point(178, 180);
            this.OpenSaveLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.OpenSaveLocation.Name = "OpenSaveLocation";
            this.OpenSaveLocation.Primary = true;
            this.OpenSaveLocation.Size = new System.Drawing.Size(113, 34);
            this.OpenSaveLocation.TabIndex = 5;
            this.OpenSaveLocation.Text = "打开下载路径";
            this.OpenSaveLocation.UseVisualStyleBackColor = true;
            this.OpenSaveLocation.Click += new System.EventHandler(this.OpenSaveLocation_Click);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(12, 142);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(121, 19);
            this.materialLabel6.TabIndex = 2;
            this.materialLabel6.Text = "保存文件名字：";
            // 
            // fileNameText
            // 
            this.fileNameText.Depth = 0;
            this.fileNameText.Hint = "";
            this.fileNameText.Location = new System.Drawing.Point(132, 141);
            this.fileNameText.MouseState = MaterialSkin.MouseState.HOVER;
            this.fileNameText.Name = "fileNameText";
            this.fileNameText.PasswordChar = '\0';
            this.fileNameText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fileNameText.SelectedText = "";
            this.fileNameText.SelectionLength = 0;
            this.fileNameText.SelectionStart = 0;
            this.fileNameText.Size = new System.Drawing.Size(184, 23);
            this.fileNameText.TabIndex = 3;
            this.fileNameText.Text = "Movie";
            this.fileNameText.UseSystemPasswordChar = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "M3U8下载器";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(682, 145);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(89, 19);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "选择线程：";
            // 
            // XianChengText
            // 
            this.XianChengText.Depth = 0;
            this.XianChengText.Hint = "";
            this.XianChengText.Location = new System.Drawing.Point(778, 144);
            this.XianChengText.MouseState = MaterialSkin.MouseState.HOVER;
            this.XianChengText.Name = "XianChengText";
            this.XianChengText.PasswordChar = '\0';
            this.XianChengText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.XianChengText.SelectedText = "";
            this.XianChengText.SelectionLength = 0;
            this.XianChengText.SelectionStart = 0;
            this.XianChengText.Size = new System.Drawing.Size(96, 23);
            this.XianChengText.TabIndex = 3;
            this.XianChengText.Text = "4";
            this.XianChengText.UseSystemPasswordChar = false;
            this.XianChengText.TextChanged += new System.EventHandler(this.XianChengText_TextChanged);
            // 
            // MuDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 643);
            this.Controls.Add(this.OpenSaveLocation);
            this.Controls.Add(this.VideoStartD);
            this.Controls.Add(this.TSRadio);
            this.Controls.Add(this.MKVRadio);
            this.Controls.Add(this.FLVRadio);
            this.Controls.Add(this.MP4Radio);
            this.Controls.Add(this.FileSaveLocationButt);
            this.Controls.Add(this.XianChengText);
            this.Controls.Add(this.fileNameText);
            this.Controls.Add(this.fileStext);
            this.Controls.Add(this.VideoUrlText);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.VideoInfo);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.textBox_Info);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MuDown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3U8下载器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MuDown_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Info;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel VideoInfo;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField VideoUrlText;
        private MaterialSkin.Controls.MaterialSingleLineTextField fileStext;
        private MaterialSkin.Controls.MaterialRaisedButton FileSaveLocationButt;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialRadioButton MP4Radio;
        private MaterialSkin.Controls.MaterialRadioButton FLVRadio;
        private MaterialSkin.Controls.MaterialRadioButton MKVRadio;
        private MaterialSkin.Controls.MaterialRadioButton TSRadio;
        private MaterialSkin.Controls.MaterialRaisedButton VideoStartD;
        private MaterialSkin.Controls.MaterialRaisedButton OpenSaveLocation;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialSingleLineTextField fileNameText;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField XianChengText;
    }
}

