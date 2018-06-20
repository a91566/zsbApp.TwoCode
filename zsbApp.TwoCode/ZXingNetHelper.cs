/*
 * 2018年6月19日 20:14:01 郑少宝
 */
using System.Drawing;
using ZXing;

namespace zsbApp.TwoCode
{
    public class ZXingNetHelper
    {
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
