﻿using DataAccess.Model;
using SelectPdf;

namespace HtmlStringToPdf
{
    public class PdfGenerator
    {
        public Subject subject;

        private string BuildHeader(Subject subject)
        {
            string header = $"<head> " +
                "<style>table{font-family: arial, sans-serif;border-collapse: collapse;width:100%;}td,th{border: 1px solid #dddddd;text-align: left;padding: 8px;}tr:nth-child(even){background-color: #dddddd;}</style></head>" +
                "<h1 style=text-align:center;background-color:lightblue;font-size:xx-large;>Teszt eredmények</h1>" +
                "<p>tesztvezető neve:</p>" +
                $"<p>tesztalany neve:{subject.Nickname}</p>" +
                $"<p><b>életkor:{subject.Age}</b></p>" +
                $"<p><b>nem:{subject.Gender.ToString()}</b></p>" +
                $"<p><b>kitöltés időpontja:{subject.SessionStartDate.ToString("yyyy.MM.dd HH:mm:ss")}</b></p>" +
                "<p><i>eredmény:</i><p >" +
                "<hr>";

            return header;
        }

        private string BuildAnswersTable(Subject subject)
        {
            string html = "<table><tr><th>kérdés</th><th>válasz</th></tr>";
            int questionNumber = 1;

            foreach (var answer in subject.QuestionAnswers)
            {
                html += $"<tr>" +
                    $"<td>{questionNumber}. {answer.Question.Text}</td>" +
                    $"<td>{answer.Answer.ToString()}</td>" +
                    $"</tr>";
                questionNumber++;
            }
            return html + "</table>";
        }

        public void WritePDF(Subject subject, string path)
        {
            string header = BuildHeader(subject);
            string answers = BuildAnswersTable(subject);
            string htmlString = header + answers;

            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument document = converter.ConvertHtmlString(htmlString);
            document.Save(path);
            document.Close();
        }
    }
}