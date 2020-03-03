using SelectPdf;
using System;

namespace HtmlStringToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            var myHtml = "<head> " +
                "<style>table{font-family: arial, sans-serif;border-collapse: collapse;width:100%;}td,th{border: 1px solid #dddddd;text-align: left;padding: 8px;}tr:nth-child(even){background-color: #dddddd;}</style></head>" +
                "<h1 style=text-align:center;background-color:lightblue;font-size:xx-large;>Teszterdmények</h1>" +
                "<p>tesztvezető neve:</p>" +
                "<p>tesztalany neve:</p>" +
                "<p><b>életkor:</b></p>" +
                "<p><b>nem:</b></p>" +
                "<p><b>kitöltés időpontja:</b></p>" +
                "<p><i>eredmény:</i><p >" +
                "<hr>" +
                "<table>" +
                "<tr>" +
                "<th>kérdés</th>" +
                "<th>válasz</th>" +
                "</tr>" +
                "<tr>" +
                "<td>kérdés1</td>" +
                "<td>válasz1</td>" +
                "</tr>" +
                "<tr>" +
                "<td>kérdés2</td>" +
                "<td>válasz2</td>" +
                "</tr>" +
                "<tr>" +
                "<td>kérdés3</td>" +
                "<td>válasz3</td>" +
                "</tr>" +
                "<tr>" +
                "<td>kérdés4</td>" +
                "<td>válasz4</td>" +
                "</tr>" +
                "</table>";

            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(myHtml);
            doc.Save("teszt_eredmények.pdf");
            doc.Close();
        }
    }
}
