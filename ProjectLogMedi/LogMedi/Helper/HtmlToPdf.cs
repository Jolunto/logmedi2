using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LogMedi.Helper
{
    public class HtmlToPdf
    {
        public Byte[] PdfSharpConvert(String html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }
        public string ByteToPdf(Byte[] b)
        {
           string ruta = Path.GetTempFileName();
            try
            {
                File.WriteAllBytes(ruta, b);
                string nuevaruta = ruta.Replace(@"\", "/");
                return "file://" + nuevaruta;
            }
            catch (Exception)
            {

                return "0";
            }
            
        }
    }
}