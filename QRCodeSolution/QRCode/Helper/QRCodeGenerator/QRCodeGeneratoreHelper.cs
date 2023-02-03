using QRCoder;
namespace QRCode.Helper.QRCodeGenerator
{
    public class QRCodeGeneratoreHelper : IQRCodeGeneratorHelper
    {
        public byte[] GenerateQRCode(string text)
        {
            byte[] QRCode = new byte[0];
            if (!string.IsNullOrEmpty(text))
            {
               QRCoder.QRCodeGenerator qrCodeGenerator = new QRCoder.QRCodeGenerator();
               QRCodeData data = qrCodeGenerator
                   .CreateQrCode(text, QRCoder.QRCodeGenerator.ECCLevel.Q);
                BitmapByteQRCode bitMap = new BitmapByteQRCode(data);
                QRCode = bitMap.GetGraphic(20);

            }

            return QRCode;
        }
    }
}
