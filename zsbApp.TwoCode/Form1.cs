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
                this.tslVer.Text = Application.ProductVersion;
                for (int i = 1; i < 41; i++)
                {
                    this.cmbQRCodeVersion.Items.Add(i);
                    this.txbQRCodeScale.Items.Add(i);
                }
                this.cmbQRCodeErrorCorrect.Items.AddRange(Enum.GetNames(typeof(QRCodeEncoder.ERROR_CORRECTION)));
                this.helper = new ThoughtWorksQRCodeHelper();
                this.cmbQRCodeErrorCorrect.SelectedIndex = 0;
                this.cmbQRCodeVersion.SelectedIndex = 9;
                this.txbQRCodeScale.Text = "4";
                this.txbLogoSize.Text = "30";
                this.initDrag();
                this.cmbAsm.SelectedIndex = 0;
            };
        }

        private ThoughtWorksQRCodeHelper helper;
        private Bitmap _bitmap;
        private string _logo;

        private void btnCreateQRCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txbContent.Text))
            {
                this.showlog("请输入数据");
                return;
            }
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
            {
                this.showlog("没有数据");
                return;
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "png (*.png)|*.png";
            saveDialog.FileName = System.Guid.NewGuid().ToString() + ".png";
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            string file = saveDialog.FileName;
            Bitmap bitmap = new Bitmap(this._bitmap.Width + 20, this._bitmap.Height + 20);
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(System.Drawing.Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
            g.DrawImage(this._bitmap, new PointF(10, 10));
            bitmap.Save(file, System.Drawing.Imaging.ImageFormat.Png);
            bitmap.Dispose();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            string file = this.getImageFile();
            if (string.IsNullOrEmpty(file))
                return;
            this.decodeQrcode(file);
        }

        /// <summary>
        /// 解析 QRCode
        /// </summary>
        /// <param name="file">文件的绝对路径</param>
        private void decodeQrcode(string file)
        {
            this.pictureBox2.Image = Image.FromFile(file);
            (string error, string content) result;
            if (this.cmbAsm.SelectedIndex == 0)
            {
                result = new ZXingNetHelper().DecodeQRCode(file);
            }
            else
            {
                result = this.helper.DecodeQRCode(file);
            }
            if (string.IsNullOrEmpty(result.error))
            {
                this.txbCotent2.Text = result.content;
            }
            else
            {
                this.txbCotent2.Text = $"发生异常：{result.error}";
            }
        }

        /// <summary>
        /// 解析 QRCode
        /// </summary>
        /// <param name="bitmap">位图</param>
        private void decodeQrcode(Bitmap bitmap)
        {
            this.pictureBox2.Image = (Image)bitmap;
            (string error, string content) result;
            if (this.cmbAsm.SelectedIndex == 0)
            {
                result = new ZXingNetHelper().DecodeQRCode(bitmap);
            }
            else
            {
                result = this.helper.DecodeQRCode(bitmap);
            }
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

        private void btnPaste_Click(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();
            if (data.GetDataPresent(typeof(Bitmap)))
            {
                this.decodeQrcode((Bitmap)data.GetData(typeof(Bitmap)));
            }
            else
            {
                this.showlog("没有符合的数据");
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null)
            {
                showlog("没有数据");
                return;
            }
            Clipboard.SetImage(this.pictureBox1.Image);
            this.showlog("已经发送到剪贴板");
        }

        private void showlog(string text)
        {
            this.tslLog.Text = text;
        }

        private void initDrag()
        {
            this.AllowDrop = true;
            this.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Link;
                else e.Effect = DragDropEffects.None;
            };
            this.DragDrop += (s, e) =>
            {
                this.tabControl1.SelectedIndex = 1;
                string file = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                this.decodeQrcode(file);
            };
        }

    }
}
