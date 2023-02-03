using Microsoft.AspNetCore.Mvc;

using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using QRCode.Models;
using System.Drawing;
using System.Drawing.Imaging;
using QRCode.Helper.QRCodeGenerator;

namespace QRCode.Controllers
{
   
   
    public class HomeController : Controller
    {
        private IQRCodeGeneratorHelper _codeGenerator;

        public HomeController(IQRCodeGeneratorHelper codeGenerator)
        {
            _codeGenerator = codeGenerator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return BadRequest();
            }

            byte[] QRCodeAsBytes = _codeGenerator.GenerateQRCode(text);
            string QRCodeAsImageBase64 =
                $"data:image/png;base64,{Convert.ToBase64String(QRCodeAsBytes)}";

            //QRCodeModel model = new QRCodeModel
            //{
            //    QRCodeText = QRCodeAsImageBase64
            //};

            ViewData["QR"] = QRCodeAsImageBase64;
            return View();
        }
    }
}