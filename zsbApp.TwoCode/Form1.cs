/*
 * 2018年6月19日 21:02:17 郑少宝 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
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
                }
                this.cmbQRCodeErrorCorrect.Items.AddRange(Enum.GetNames(typeof(QRCodeEncoder.ERROR_CORRECTION)));
                this.thHelper = new ThoughtWorksQRCodeHelper();
                this.zxingHelper = new ZXingNetHelper();
                this.cmbQRCodeErrorCorrect.SelectedIndex = 0;
                this.cmbQRCodeVersion.SelectedIndex = 0;
                this.txbQRCodeScale.Text = "4";
                this.txbLogoSize.Text = "30";
                this.initDrag();
                this.cmbAsm.SelectedIndex = 0;
                this.txbContent.Text = System.DateTime.Now.ToLongDateString();
            };
        }

        private ThoughtWorksQRCodeHelper thHelper;
        private ZXingNetHelper zxingHelper;
        private Bitmap _bitmap;
        private string _logo;

        private void btnCreateQRCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txbContent.Text))
            {
                this.showlog("请输入数据");
                return;
            }
            int ver = System.Convert.ToInt32(this.cmbQRCodeVersion.Text);
            int size = System.Convert.ToInt32(this.txbQRCodeScale.Text);
            int logoSize = System.Convert.ToInt32(this.txbLogoSize.Text);

            (string error, Bitmap qrcodeBitbmp) result;
            if (this.cmbAsm.SelectedIndex == 0)
            {
                var error = ZXing.QrCode.Internal.ErrorCorrectionLevel.L;
                if (this.cmbQRCodeErrorCorrect.SelectedIndex == 1)
                {
                    error = ZXing.QrCode.Internal.ErrorCorrectionLevel.M;
                }
                else if (this.cmbQRCodeErrorCorrect.SelectedIndex == 2)
                {
                    error = ZXing.QrCode.Internal.ErrorCorrectionLevel.Q;
                }
                else if (this.cmbQRCodeErrorCorrect.SelectedIndex == 3)
                {
                    error = ZXing.QrCode.Internal.ErrorCorrectionLevel.H;
                }
                result = this.zxingHelper.CreateQRCode(this.txbContent.Text, size, ver, error, this._logo, logoSize);
            }
            else
            {
                QRCodeEncoder.ERROR_CORRECTION error = (QRCodeEncoder.ERROR_CORRECTION)Enum.Parse(typeof(QRCodeEncoder.ERROR_CORRECTION), this.cmbQRCodeErrorCorrect.Text);
                result = thHelper.CreateQRCode(this.txbContent.Text, size, ver, error, this._logo, logoSize);
            }
            if (string.IsNullOrEmpty(result.error))
            {
                this._bitmap = result.qrcodeBitbmp;
                this.pictureBox1.Image = result.qrcodeBitbmp;
            }
            else
            {
                this.showlog(result.error);
            }
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
                result = this.thHelper.DecodeQRCode(file);
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
                result = this.zxingHelper.DecodeQRCode(bitmap);
            }
            else
            {
                result = this.thHelper.DecodeQRCode(bitmap);
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
            if(!string.IsNullOrEmpty(text))
                this.timer1.Enabled = true;
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

        private void txbContent_TextChanged(object sender, EventArgs e)
        {
            var c = System.Text.Encoding.Default.GetByteCount(this.txbContent.Text).ToString();
            this.showlog(c.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.showlog("");
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txbCotent2.Text))
            {
                this.showlog("没有可解析的数据");
                return;
            }
            string temp = this.txbCotent2.Text.Replace(@"http://j2w.tv:83?", "");
            string content = null;
            try
            {
                content = this.decrypt(temp, "b#s^$5.u", "5iG3-3&w");
            }
            catch (Exception ex)
            {
                MessageBox.Show("解密发生了异常：" + ex.Message);
                return;
            }
            if (string.IsNullOrEmpty(content))
            {
                this.showlog("未能正确处理数据");
                return;
            }
            var words = content.Split('|');
            if (words.Length != 7 && words.Length != 8)
            {
                MessageBox.Show("数据可能错误：" + content);
                return;
            }
            List<string> result = new List<string>();
            result.Add($"机构代码:{words[0]}");
            result.Add($"报告编号:{words[1]}");
            result.Add($"检测结论:{words[2]}");
            result.Add($"报告日期:{words[3]}");
            result.Add($"标准编码:{words[4]}");
            result.Add($"样品数量:{words[5]}");
            result.Add($"工程名称:{words[6]}");
            if(words.Length>7)
                result.Add($"样品龄期:{words[7]}");
            MessageBox.Show(string.Join(System.Environment.NewLine, result));
        }

        /// <summary>
        /// 解密一个密文字符串(仅在特别需要时调用,一般直接调用缺省密钥的方法即可)
        /// </summary>
        /// <param name="data">待解密的密文串</param>
        /// <param name="seckey">解密密钥(8字符64位)</param>
        /// <param name="iv">偏移</param>
        /// <returns>返回解密后的明文串</returns>
        private string decrypt(string data, string seckey, string iv)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(seckey);
            byte[] by_IV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms,
                cryptoProvider.CreateDecryptor(byKey, by_IV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.qrcode.com/en/");
        }
    }
}
