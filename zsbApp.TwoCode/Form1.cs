/*
 * 2018年6月19日 21:02:17 郑少宝
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;

namespace zsbApp.TwoCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += (s, e) =>
            {
                for (int i = 1; i < 31; i++)
                {
                    this.cmbQRCodeVersion.Items.Add(i);
                }
                this.cmbQRCodeErrorCorrect.Items.AddRange(Enum.GetNames(typeof(QRCodeEncoder.ERROR_CORRECTION)));
                this.helper = new ThoughtWorksQRCodeHelper();

                this.cmbQRCodeErrorCorrect.SelectedIndex = 0;
                this.cmbQRCodeVersion.SelectedIndex = 9;
                this.txbQRCodeScale.Text = "4";
                this.txbLogoSize.Text = "30";
            };
        }

        private ThoughtWorksQRCodeHelper helper;
        private Bitmap _bitmap;
        private string _logo;

        private void btnCreateQRCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txbContent.Text))
                return;
            int ver = System.Convert.ToInt32(this.cmbQRCodeVersion.SelectedValue);
            int size = System.Convert.ToInt32(this.txbQRCodeScale.Text);
            int logoSize = System.Convert.ToInt32(this.txbLogoSize.Text);
            QRCodeEncoder.ERROR_CORRECTION error = (QRCodeEncoder.ERROR_CORRECTION)Enum.Parse(typeof(QRCodeEncoder.ERROR_CORRECTION), this.cmbQRCodeErrorCorrect.Text);
            var result = helper.CreateQRCode(this.txbContent.Text, size, ver, error, this._logo, logoSize);
            this._bitmap = result.qrcodeBitbmp;
            this.pictureBox1.Image = result.qrcodeBitbmp;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (this._bitmap == null)
                return;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "png (*.png)|*.png";
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            string file = saveDialog.FileName;
            Bitmap bitmap = new Bitmap(this._bitmap.Width + 30, this._bitmap.Height + 30);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(System.Drawing.Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
            g.DrawImage(this._bitmap, new PointF(15, 15));
            bitmap.Save(file, System.Drawing.Imaging.ImageFormat.Png);
            bitmap.Dispose();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            string file = this.getImageFile();
            if (string.IsNullOrEmpty(file))
                return;
            this.pictureBox2.Image = Image.FromFile(file);
            var result = this.helper.DecodeQRCode(file);
            if (string.IsNullOrEmpty(result.error))
            {
                this.txbCotent2.Text = result.content;
            }
            else
            {
                this.txbCotent2.Text = $"发生异常：{result.error}";
            }
        }

        private string getImageFile()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "图片文件|*.jpg;*.png;*.gif|All files(*.*)|*.*";
            if (openDialog.ShowDialog() != DialogResult.OK)
                return null;
            return openDialog.FileName;
        }

        private void btnSelectLogo_Click(object sender, EventArgs e)
        {
            string file = this.getImageFile();
            if (string.IsNullOrEmpty(file))
                return;
            this.pictureBox3.Image = Image.FromFile(file);
            this._logo = file;
        }
    }
}
