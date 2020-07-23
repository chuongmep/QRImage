using System.Drawing;
using QRCoder;

/// <summary>
/// QrCode
/// </summary>
public static class QrCode

{

    /// <summary>
    /// Create QRCode String Sample
    /// </summary>
    /// <param name="str"></param>
    /// <param name="Pixel"></param>
    /// <returns></returns>
    public static Bitmap CreateQRCodeString(string str = "Qrcode", int Pixel = 20)
    {
        QRCodeGenerator QrCodeGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = QrCodeGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.M);

        QRCode QrCode = new QRCode(qrCodeData);

        Bitmap QrcodeimageBitmap = QrCode.GetGraphic(Pixel);

        return QrcodeimageBitmap;
    }


    /// <summary>
    /// Create QRCode Color Option Extend
    /// </summary>
    /// <param name="str">String Gen QR</param>
    /// <param name="Pixel">Pixel input a Int</param>
    /// <param name="ColorQR">Color in QR</param>
    /// <param name="ColorBG">Color BackGround</param>
    /// <returns></returns>
    public static Bitmap CreateQRCodeColor(string str, int Pixel, System.Drawing.Color ColorQR, System.Drawing.Color ColorBG)
    {

        QRCodeGenerator QrCodeGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = QrCodeGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.M);

        QRCode QrCode = new QRCode(qrCodeData);

        Bitmap QrcodeimageBitmap = QrCode.GetGraphic(Pixel, ColorQR, ColorBG, true);

        return QrcodeimageBitmap;
    }


}

