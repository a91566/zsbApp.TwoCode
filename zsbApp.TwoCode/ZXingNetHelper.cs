/*
 * 2018年6月19日 20:14:01 郑少宝
 */
using System;
using System.Drawing;
using ZXing;

namespace zsbApp.TwoCode
{
    public class ZXingNetHelper
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="qRCodeScale">大小</param>
        /// <param name="qRCodeVersion">版本</param>
        /// <param name="qRCodeErrorCorrect">容错</param>
        /// <param name="logoFile">logo文件</param>
        /// <param name="logoSize">logo大小</param>
        /// <returns></returns>
        public (string error, Bitmap qrcodeBitbmp) CreateQRCode(string content, int qRCodeScale, int qRCodeVersion,
            ZXing.QrCode.Internal.ErrorCorrectionLevel qRCodeErrorCorrect, string logoFile, int logoSize)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = new ZXing.QrCode.QrCodeEncodingOptions() {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = qRCodeScale,
                Height = qRCodeScale,
                ErrorCorrection = qRCodeErrorCorrect,
                QrVersion = qRCodeVersion,
                Margin = 0
            };
            try
            {
                Bitmap qrcode = writer.Write(content);
                if (!string.IsNullOrEmpty(logoFile))
                {
                    Graphics g = Graphics.FromImage(qrcode);
                    Bitmap bitmapLogo = new Bitmap(logoFile);
                    bitmapLogo = new Bitmap(bitmapLogo, new System.Drawing.Size(logoSize, logoSize));
                    PointF point = new PointF(qrcode.Width / 2 - logoSize / 2, qrcode.Height / 2 - logoSize / 2);
                    g.DrawImage(bitmapLogo, point);
                }
                return (null, qrcode);
            }
            catch (Exception ex)
            {
                return (ex.Message, null);
            }
        }

        /// <summary>
        /// 解析二维码
        /// </summary>
        /// <param name="file">文件绝对路径</param>
        /// <returns></returns>
        public (string error, string content) DecodeQRCode(string file)
        {
            BarcodeReader reader = new BarcodeReader();
            reader.Options.CharacterSet = "UTF-8";
            using (Bitmap bmp = new Bitmap(file))
            {
                Result result = reader.Decode(bmp);
                if (result == null)
                {
                    return ("未能识别", "");
                }
                return (null, result.Text);
            }
        }

        /// <summary>
        /// 解析二维码
        /// </summary>
        /// <param name="file">文件绝对路径</param>
        /// <returns></returns>
        public (string error, string content) DecodeQRCode(Bitmap bitmap)
        {
            BarcodeReader reader = new BarcodeReader();
            reader.Options.CharacterSet = "UTF-8";
            Result result = reader.Decode(bitmap);
            if (result == null)
            {
                return (null, null);
            }
            return (null, result.Text);
        }
    }
}
