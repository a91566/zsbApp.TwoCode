namespace zsbApp.TwoCode
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.cmbQRCodeErrorCorrect = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbQRCodeScale = new System.Windows.Forms.TextBox();
            this.cmbQRCodeVersion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateQRCode = new System.Windows.Forms.Button();
            this.txbContent = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txbCotent2 = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnSelectLogo = new System.Windows.Forms.Button();
            this.txbLogoSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(108, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(889, 584);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(881, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "生成 QR Code";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txbLogoSize);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btnSelectLogo);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnSaveAs);
            this.splitContainer1.Panel1.Controls.Add(this.cmbQRCodeErrorCorrect);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txbQRCodeScale);
            this.splitContainer1.Panel1.Controls.Add(this.cmbQRCodeVersion);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnCreateQRCode);
            this.splitContainer1.Panel1.Controls.Add(this.txbContent);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(875, 540);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.TabIndex = 4;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAs.Location = new System.Drawing.Point(140, 258);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(102, 42);
            this.btnSaveAs.TabIndex = 11;
            this.btnSaveAs.Text = "另存为...";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // cmbQRCodeErrorCorrect
            // 
            this.cmbQRCodeErrorCorrect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQRCodeErrorCorrect.FormattingEnabled = true;
            this.cmbQRCodeErrorCorrect.Location = new System.Drawing.Point(235, 167);
            this.cmbQRCodeErrorCorrect.Name = "cmbQRCodeErrorCorrect";
            this.cmbQRCodeErrorCorrect.Size = new System.Drawing.Size(92, 24);
            this.cmbQRCodeErrorCorrect.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "容错";
            // 
            // txbQRCodeScale
            // 
            this.txbQRCodeScale.Location = new System.Drawing.Point(64, 208);
            this.txbQRCodeScale.Name = "txbQRCodeScale";
            this.txbQRCodeScale.Size = new System.Drawing.Size(101, 26);
            this.txbQRCodeScale.TabIndex = 8;
            // 
            // cmbQRCodeVersion
            // 
            this.cmbQRCodeVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQRCodeVersion.FormattingEnabled = true;
            this.cmbQRCodeVersion.Location = new System.Drawing.Point(64, 167);
            this.cmbQRCodeVersion.Name = "cmbQRCodeVersion";
            this.cmbQRCodeVersion.Size = new System.Drawing.Size(101, 24);
            this.cmbQRCodeVersion.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "版本";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "大小";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "内容";
            // 
            // btnCreateQRCode
            // 
            this.btnCreateQRCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateQRCode.Location = new System.Drawing.Point(20, 258);
            this.btnCreateQRCode.Name = "btnCreateQRCode";
            this.btnCreateQRCode.Size = new System.Drawing.Size(89, 42);
            this.btnCreateQRCode.TabIndex = 2;
            this.btnCreateQRCode.Text = "生成";
            this.btnCreateQRCode.UseVisualStyleBackColor = true;
            this.btnCreateQRCode.Click += new System.EventHandler(this.btnCreateQRCode_Click);
            // 
            // txbContent
            // 
            this.txbContent.Location = new System.Drawing.Point(64, 13);
            this.txbContent.Multiline = true;
            this.txbContent.Name = "txbContent";
            this.txbContent.Size = new System.Drawing.Size(263, 138);
            this.txbContent.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(532, 540);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(881, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "解析 QR Code";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txbCotent2);
            this.splitContainer2.Panel1.Controls.Add(this.btnSelectFile);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer2.Size = new System.Drawing.Size(875, 540);
            this.splitContainer2.SplitterDistance = 291;
            this.splitContainer2.TabIndex = 13;
            // 
            // txbCotent2
            // 
            this.txbCotent2.Location = new System.Drawing.Point(5, 63);
            this.txbCotent2.Multiline = true;
            this.txbCotent2.Name = "txbCotent2";
            this.txbCotent2.Size = new System.Drawing.Size(283, 378);
            this.txbCotent2.TabIndex = 13;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFile.Location = new System.Drawing.Point(8, 15);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(102, 42);
            this.btnSelectFile.TabIndex = 12;
            this.btnSelectFile.Text = "选择...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(580, 540);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "logo";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(64, 355);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(206, 140);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // btnSelectLogo
            // 
            this.btnSelectLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectLogo.Location = new System.Drawing.Point(64, 321);
            this.btnSelectLogo.Name = "btnSelectLogo";
            this.btnSelectLogo.Size = new System.Drawing.Size(54, 28);
            this.btnSelectLogo.TabIndex = 14;
            this.btnSelectLogo.Text = "添加";
            this.btnSelectLogo.UseVisualStyleBackColor = true;
            this.btnSelectLogo.Click += new System.EventHandler(this.btnSelectLogo_Click);
            // 
            // txbLogoSize
            // 
            this.txbLogoSize.Location = new System.Drawing.Point(64, 509);
            this.txbLogoSize.Name = "txbLogoSize";
            this.txbLogoSize.Size = new System.Drawing.Size(101, 26);
            this.txbLogoSize.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "大小";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 584);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QRCode 生成与解析";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCreateQRCode;
        private System.Windows.Forms.TextBox txbContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbQRCodeVersion;
        private System.Windows.Forms.TextBox txbQRCodeScale;
        private System.Windows.Forms.ComboBox cmbQRCodeErrorCorrect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txbCotent2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnSelectLogo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbLogoSize;
        private System.Windows.Forms.Label label3;
    }
}

