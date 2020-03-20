using BusinessLogic;
using CoreHtmlToImage;
using DataAccess.Model;
using SelectPdf;

namespace HtmlStringToPdf
{
    public class PdfGenerator
    {
        public HtmlProvider HtmlProvider { get; set; }
        public Subject Subject { get; set; }

        public void WritePDF(Subject subject, string path)
        {
            TestEvaluator evaluation = new TestEvaluator();
            string html = HtmlProvider.GetHtml();

            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument document = converter.ConvertHtmlString(html);
            document.Save(path);
            document.Close();
        }
    }
}
