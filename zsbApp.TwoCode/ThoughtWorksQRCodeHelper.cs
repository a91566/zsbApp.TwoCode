/*
 * 2018年6月19日 20:14:01 郑少宝
 */
using System;
using System.Drawing;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace zsbApp.TwoCode
{
    public class ThoughtWorksQRCodeHelper
    {

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="qRCodeScale">大小</param>
        /// <param name="qRCodeVersion">版本</param>
        /// <param name="qRCodeErrorCorrect">容错</param>
        /// <param name="logoFile">logo文件</param>
        /// <returns></returns>
        public (string error, Bitmap qrcodeBitbmp) CreateQRCode(string content, int qRCodeScale, int qRCodeVersion, 
            QRCodeEncoder.ERROR_CORRECTION qRCodeErrorCorrect, string logoFile, int logoSize)
        {
            QRCodeEncoder qrEncoder = new QRCodeEncoder();
            qrEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrEncoder.QRCodeScale = qRCodeScale;
            qrEncoder.QRCodeVersion = qRCodeVersion;
            qrEncoder.QRCodeErrorCorrect = qRCodeErrorCorrect;
            try
            {
                Bitmap qrcode = qrEncoder.Encode(content, Encoding.UTF8);
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
        public (string error, string content) DecodeQRCode(string file)
        {
            var bitmap = new Bitmap(file);
            QRCodeDecoder qrDecoder = new QRCodeDecoder();
            QRCodeImage qrImage = new QRCodeBitmapImage(bitmap);
            try
            {
                string content = qrDecoder.decode(qrImage, Encoding.UTF8);
                return (null, content);
            }
            catch (Exception ex)
            {
                return (ex.Message, null);
            }
        }
    }
}
