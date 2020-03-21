using CoreHtmlToImage;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class PreviewImageGenerator
    {
        public HtmlProvider HtmlProvider {get; set;}

        public byte[] ConvertHtmlToImage()
        {
            string html = HtmlProvider.GetHtml();
            var converter = new HtmlConverter();
            byte[] bytes = converter.FromHtmlString(html);
            return bytes;
        }
    }
}
