namespace VideoDownload
{
    partial class MuShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MuShow));
            this.PlayMovieButt = new MaterialSkin.Controls.MaterialRaisedButton();
            this.VideoStartF = new MaterialSkin.Controls.MaterialRaisedButton();
            this.VideoNameText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.MovieMenuC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.推荐资源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制查找ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MovieID = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.解析源ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MovieMenuC.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayMovieButt
            // 
            this.PlayMovieButt.BackColor = System.Drawing.Color.DarkOrange;
            this.PlayMovieButt.Depth = 0;
            this.PlayMovieButt.Font = new System.Drawing.Font("宋体", 12F);
            this.PlayMovieButt.Location = new System.Drawing.Point(769, 69);
            this.PlayMovieButt.MouseState = MaterialSkin.MouseState.HOVER;
            this.PlayMovieButt.Name = "PlayMovieButt";
            this.PlayMovieButt.Primary = true;
            this.PlayMovieButt.Size = new System.Drawing.Size(113, 34);
            this.PlayMovieButt.TabIndex = 24;
            this.PlayMovieButt.Text = "点击播放";
            this.PlayMovieButt.UseVisualStyleBackColor = false;
            this.PlayMovieButt.Click += new System.EventHandler(this.PlayMovieButt_Click);
            // 
            // VideoStartF
            // 
            this.VideoStartF.Depth = 0;
            this.VideoStartF.Font = new System.Drawing.Font("宋体", 12F);
            this.VideoStartF.Location = new System.Drawing.Point(334, 69);
            this.VideoStartF.MouseState = MaterialSkin.MouseState.HOVER;
            this.VideoStartF.Name = "VideoStartF";
            this.VideoStartF.Primary = true;
            this.VideoStartF.Size = new System.Drawing.Size(113, 34);
            this.VideoStartF.TabIndex = 23;
            this.VideoStartF.Text = "立即查找";
            this.VideoStartF.UseVisualStyleBackColor = true;
            this.VideoStartF.Click += new System.EventHandler(this.VideoStartF_Click);
            // 
            // VideoNameText
            // 
            this.VideoNameText.Depth = 0;
            this.VideoNameText.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VideoNameText.Hint = "";
            this.VideoNameText.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.VideoNameText.Location = new System.Drawing.Point(106, 72);
            this.VideoNameText.MouseState = MaterialSkin.MouseState.HOVER;
            this.VideoNameText.Name = "VideoNameText";
            this.VideoNameText.PasswordChar = '\0';
            this.VideoNameText.SelectedText = "";
            this.VideoNameText.SelectionLength = 0;
            this.VideoNameText.SelectionStart = 0;
            this.VideoNameText.Size = new System.Drawing.Size(222, 23);
            this.VideoNameText.TabIndex = 0;
            this.VideoNameText.Text = "奇异博士";
            this.VideoNameText.UseSystemPasswordChar = false;
            this.VideoNameText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VideoNameText_KeyDown);
            this.VideoNameText.TextChanged += new System.EventHandler(this.VideoNameText_TextChanged);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(11, 72);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(89, 19);
            this.materialLabel3.TabIndex = 13;
            this.materialLabel3.Text = "搜索视频：";
            // 
            // textBox_Info
            // 
            this.textBox_Info.BackColor = System.Drawing.Color.Wheat;
            this.textBox_Info.ContextMenuStrip = this.MovieMenuC;
            this.textBox_Info.Font = new System.Drawing.Font("微软雅黑 Light", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Info.ForeColor = System.Drawing.Color.Black;
            this.textBox_Info.Location = new System.Drawing.Point(10, 109);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ReadOnly = true;
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(872, 487);
            this.textBox_Info.TabIndex = 6;
            // 
            // MovieMenuC
            // 
            this.MovieMenuC.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MovieMenuC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.推荐资源ToolStripMenuItem,
            this.刷新列表ToolStripMenuItem,
            this.清空目录ToolStripMenuItem,
            this.复制查找ToolStripMenuItem});
            this.MovieMenuC.Name = "MovieMenuC";
            this.MovieMenuC.Size = new System.Drawing.Size(181, 114);
            // 
            // 推荐资源ToolStripMenuItem
            // 
            this.推荐资源ToolStripMenuItem.Name = "推荐资源ToolStripMenuItem";
            this.推荐资源ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.推荐资源ToolStripMenuItem.Text = "推荐资源";
            this.推荐资源ToolStripMenuItem.Click += new System.EventHandler(this.推荐资源ToolStripMenuItem_Click);
            // 
            // 刷新列表ToolStripMenuItem
            // 
            this.刷新列表ToolStripMenuItem.Name = "刷新列表ToolStripMenuItem";
            this.刷新列表ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.刷新列表ToolStripMenuItem.Text = "刷新列表";
            this.刷新列表ToolStripMenuItem.Click += new System.EventHandler(this.刷新列表ToolStripMenuItem_Click);
            // 
            // 清空目录ToolStripMenuItem
            // 
            this.清空目录ToolStripMenuItem.Name = "清空目录ToolStripMenuItem";
            this.清空目录ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.清空目录ToolStripMenuItem.Text = "清空目录";
            this.清空目录ToolStripMenuItem.Click += new System.EventHandler(this.清空目录ToolStripMenuItem_Click);
            // 
            // 复制查找ToolStripMenuItem
            // 
            this.复制查找ToolStripMenuItem.Name = "复制查找ToolStripMenuItem";
            this.复制查找ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.复制查找ToolStripMenuItem.Text = "查找选中电影";
            this.复制查找ToolStripMenuItem.Click += new System.EventHandler(this.复制查找ToolStripMenuItem_Click);
            // 
            // MovieID
            // 
            this.MovieID.Depth = 0;
            this.MovieID.Hint = "";
            this.MovieID.Location = new System.Drawing.Point(656, 72);
            this.MovieID.MouseState = MaterialSkin.MouseState.HOVER;
            this.MovieID.Name = "MovieID";
            this.MovieID.PasswordChar = '\0';
            this.MovieID.SelectedText = "";
            this.MovieID.SelectionLength = 0;
            this.MovieID.SelectionStart = 0;
            this.MovieID.Size = new System.Drawing.Size(90, 23);
            this.MovieID.TabIndex = 21;
            this.MovieID.Text = "0";
            this.MovieID.UseSystemPasswordChar = false;
            this.MovieID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MovieID_KeyDown);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(470, 76);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(169, 19);
            this.materialLabel1.TabIndex = 13;
            this.materialLabel1.Text = "选择并输入视频编号：";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.解析源ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(812, 75);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(79, 25);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 解析源ToolStripMenuItem
            // 
            this.解析源ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.解析源ToolStripMenuItem.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.解析源ToolStripMenuItem.ForeColor = System.Drawing.Color.Green;
            this.解析源ToolStripMenuItem.Name = "解析源ToolStripMenuItem";
            this.解析源ToolStripMenuItem.Size = new System.Drawing.Size(71, 21);
            this.解析源ToolStripMenuItem.Text = "解析源";
            // 
            // MuShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 603);
            this.Controls.Add(this.PlayMovieButt);
            this.Controls.Add(this.VideoStartF);
            this.Controls.Add(this.MovieID);
            this.Controls.Add(this.VideoNameText);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.textBox_Info);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MuShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电影查找";
            this.Load += new System.EventHandler(this.MuShow_Load);
            this.MovieMenuC.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton PlayMovieButt;
        private MaterialSkin.Controls.MaterialRaisedButton VideoStartF;
        private MaterialSkin.Controls.MaterialSingleLineTextField VideoNameText;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.TextBox textBox_Info;
        private MaterialSkin.Controls.MaterialSingleLineTextField MovieID;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 解析源ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip MovieMenuC;
        private System.Windows.Forms.ToolStripMenuItem 推荐资源ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制查找ToolStripMenuItem;
    }
}