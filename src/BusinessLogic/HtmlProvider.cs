using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class HtmlProvider
    {
        public Subject Subject { get; set; }

        public HtmlProvider(Subject subject)
        {
            Subject = subject;
        }

        private string BuildHeader()
        {
            TestEvaluator evaluation = new TestEvaluator();
            string header = $"<head><meta charset='UTF8'> " +
                "<style>table{font-family: arial, sans-serif;border-collapse: collapse;width:100%;}td,th{border: 1px solid #dddddd;text-align: left;padding: 8px;}tr:nth-child(even){background-color: #dddddd;}</style></head>" +
                "<h1 style=text-align:center;background-color:lightblue;font-size:xx-large;>Teszt eredmények</h1>" +
                "<p>tesztvezető neve:</p>" +
                $"<p>tesztalany neve: {Subject.Nickname}</p>" +
                $"<p><b>életkor: {Subject.Age}</b></p>" +
                $"<p><b>nem: {Subject.Gender.ToString()}</b></p>" +
                $"<p><b>kitöltés időpontja: {Subject.SessionStartDate.ToString("yyyy.MM.dd HH:mm:ss")}</b></p>" +
                $"<p><i>eredmény: {evaluation.Evaluate(Subject).ToString()}</i><p >" +
                "<hr>";

            return header;
        }

        private string BuildAnswersTable()
        {
            string html = "<table><tr><th>kérdés</th><th>válasz</th></tr>";
            int questionNumber = 1;

            foreach (var answer in Subject.QuestionAnswers)
            {
                html += $"<tr>" +
                    $"<td>{questionNumber}. {answer.Question.Text}</td>" +
                    $"<td>{answer.Answer.ToString()}</td>" +
                    $"</tr>";
                questionNumber++;
            }
            return html + "</table>";
        }
        public string GetHtml()
        {
            return $"{BuildHeader()+BuildAnswersTable()}"; 
        }
    }
}
