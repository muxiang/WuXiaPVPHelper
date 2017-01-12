namespace WuXiaPVPHelper
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIcons = new System.Windows.Forms.TrackBar();
            this.picShenDao = new System.Windows.Forms.PictureBox();
            this.picWuDu = new System.Windows.Forms.PictureBox();
            this.picTangMen = new System.Windows.Forms.PictureBox();
            this.picGaiBang = new System.Windows.Forms.PictureBox();
            this.picZhenWu = new System.Windows.Forms.PictureBox();
            this.picShenWei = new System.Windows.Forms.PictureBox();
            this.picTianXiang = new System.Windows.Forms.PictureBox();
            this.cmbCareers = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbIcons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShenDao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWuDu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTangMen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGaiBang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZhenWu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShenWei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTianXiang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "对战职业:";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 120);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(386, 245);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            this.listView1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.listView1_PreviewKeyDown);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(222, 76);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "图标大小:";
            // 
            // tbIcons
            // 
            this.tbIcons.AutoSize = false;
            this.tbIcons.LargeChange = 40;
            this.tbIcons.Location = new System.Drawing.Point(95, 76);
            this.tbIcons.Maximum = 80;
            this.tbIcons.Minimum = 40;
            this.tbIcons.Name = "tbIcons";
            this.tbIcons.Size = new System.Drawing.Size(121, 30);
            this.tbIcons.SmallChange = 20;
            this.tbIcons.TabIndex = 5;
            this.tbIcons.TickFrequency = 20;
            this.tbIcons.Value = 60;
            // 
            // picShenDao
            // 
            this.picShenDao.Image = global::WuXiaPVPHelper.Properties.Resources.神刀;
            this.picShenDao.Location = new System.Drawing.Point(357, 13);
            this.picShenDao.Name = "picShenDao";
            this.picShenDao.Size = new System.Drawing.Size(38, 38);
            this.picShenDao.TabIndex = 6;
            this.picShenDao.TabStop = false;
            this.picShenDao.Tag = "神刀";
            // 
            // picWuDu
            // 
            this.picWuDu.Image = global::WuXiaPVPHelper.Properties.Resources.五毒;
            this.picWuDu.Location = new System.Drawing.Point(313, 13);
            this.picWuDu.Name = "picWuDu";
            this.picWuDu.Size = new System.Drawing.Size(38, 38);
            this.picWuDu.TabIndex = 6;
            this.picWuDu.TabStop = false;
            this.picWuDu.Tag = "五毒";
            // 
            // picTangMen
            // 
            this.picTangMen.Image = global::WuXiaPVPHelper.Properties.Resources.唐门;
            this.picTangMen.Location = new System.Drawing.Point(269, 13);
            this.picTangMen.Name = "picTangMen";
            this.picTangMen.Size = new System.Drawing.Size(38, 38);
            this.picTangMen.TabIndex = 6;
            this.picTangMen.TabStop = false;
            this.picTangMen.Tag = "唐门";
            // 
            // picGaiBang
            // 
            this.picGaiBang.Image = global::WuXiaPVPHelper.Properties.Resources.丐帮;
            this.picGaiBang.Location = new System.Drawing.Point(225, 13);
            this.picGaiBang.Name = "picGaiBang";
            this.picGaiBang.Size = new System.Drawing.Size(38, 38);
            this.picGaiBang.TabIndex = 6;
            this.picGaiBang.TabStop = false;
            this.picGaiBang.Tag = "丐帮";
            // 
            // picZhenWu
            // 
            this.picZhenWu.Image = global::WuXiaPVPHelper.Properties.Resources.真武;
            this.picZhenWu.Location = new System.Drawing.Point(181, 13);
            this.picZhenWu.Name = "picZhenWu";
            this.picZhenWu.Size = new System.Drawing.Size(38, 38);
            this.picZhenWu.TabIndex = 6;
            this.picZhenWu.TabStop = false;
            this.picZhenWu.Tag = "真武";
            // 
            // picShenWei
            // 
            this.picShenWei.Image = global::WuXiaPVPHelper.Properties.Resources.神威;
            this.picShenWei.Location = new System.Drawing.Point(137, 13);
            this.picShenWei.Name = "picShenWei";
            this.picShenWei.Size = new System.Drawing.Size(38, 38);
            this.picShenWei.TabIndex = 6;
            this.picShenWei.TabStop = false;
            this.picShenWei.Tag = "神威";
            // 
            // picTianXiang
            // 
            this.picTianXiang.Image = global::WuXiaPVPHelper.Properties.Resources.天香;
            this.picTianXiang.Location = new System.Drawing.Point(93, 13);
            this.picTianXiang.Name = "picTianXiang";
            this.picTianXiang.Size = new System.Drawing.Size(38, 38);
            this.picTianXiang.TabIndex = 6;
            this.picTianXiang.TabStop = false;
            this.picTianXiang.Tag = "天香";
            // 
            // cmbCareers
            // 
            this.cmbCareers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCareers.FormattingEnabled = true;
            this.cmbCareers.Location = new System.Drawing.Point(303, 79);
            this.cmbCareers.Name = "cmbCareers";
            this.cmbCareers.Size = new System.Drawing.Size(121, 20);
            this.cmbCareers.TabIndex = 1;
            this.cmbCareers.Visible = false;
            this.cmbCareers.SelectedIndexChanged += new System.EventHandler(this.cmbCareers_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 377);
            this.Controls.Add(this.picShenDao);
            this.Controls.Add(this.picWuDu);
            this.Controls.Add(this.picTangMen);
            this.Controls.Add(this.picGaiBang);
            this.Controls.Add(this.picZhenWu);
            this.Controls.Add(this.picShenWei);
            this.Controls.Add(this.picTianXiang);
            this.Controls.Add(this.tbIcons);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCareers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "天刀论剑计时器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbIcons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShenDao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWuDu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTangMen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGaiBang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZhenWu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShenWei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTianXiang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbIcons;
        private System.Windows.Forms.PictureBox picTianXiang;
        private System.Windows.Forms.PictureBox picShenWei;
        private System.Windows.Forms.PictureBox picZhenWu;
        private System.Windows.Forms.PictureBox picGaiBang;
        private System.Windows.Forms.PictureBox picTangMen;
        private System.Windows.Forms.PictureBox picWuDu;
        private System.Windows.Forms.PictureBox picShenDao;
        private System.Windows.Forms.ComboBox cmbCareers;
    }
}

