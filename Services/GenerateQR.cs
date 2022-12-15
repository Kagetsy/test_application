using Net.Codecrete.QrCodeGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Interfaces;

namespace WebApplication2.Services
{
    /// <summary>
    /// генератор куар кодов
    /// </summary>
    public class GenerateQR : IGenerateQR
    {
        public void GenerateQr(string shortUrl, string name)
        {
            var qr = QrCode.EncodeText(shortUrl, QrCode.Ecc.Medium);
            string svg = qr.ToSvgString(4);
            File.WriteAllText($"{name}.svg", svg, Encoding.UTF8);
        }
    }
}
