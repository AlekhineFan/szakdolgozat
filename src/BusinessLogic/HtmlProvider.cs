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
            TestEvaluator evaluator = new TestEvaluator();
            string genderInHungarian = (Subject.Gender.ToString() == "Férfi")? "Férfi" : "Nő";
            string header = $"<head><meta charset='UTF8'> " +
                "<style>table{font-family: arial, sans-serif;border-collapse: collapse;width:100%;}td,th{border: 1px solid #dddddd;text-align: left;padding: 8px;}tr:nth-child(even){background-color: #dddddd;}</style></head>" +
                "<h1 style=text-align:center;background-color:lightblue;font-size:xx-large;>Teszteredmények</h1>" +
                $"<p><b>tesztalany neve: {Subject.Nickname}</b></p>" +
                $"<p><b>életkor: {Subject.Age}</b></p>" +
                $"<p><b>nem: {genderInHungarian}</b></p>" +
                $"<p><b>kitöltés időpontja: {Subject.SessionStartDate.ToString("yyyy.MM.dd HH:mm:ss")}</b></p>" +
                $"<p><i><u>eredmény: {evaluator.Evaluate(Subject).ToString()}</u></i><p>" +
                "<hr>";

            return header;
        }

        private string BuildAnswersTable()
        {
            string html = "<table><tr><th>kérdés</th><th>válasz</th></tr>";
            int questionNumber = 1;

            foreach (var answer in Subject.QuestionAnswers)
            {
                string answerInHungarian = (answer.Answer.ToString() == "True") ? "jellemző" : "nem jellemző";
                string hemisphere = (answer.Question.Hemisphere.ToString() == "Left") ? "bal" : "jobb";

                html += $"<tr>" +
                    $"<td>{questionNumber}. {answer.Question.Text} ({hemisphere})</td>" +
                    $"<td>{answerInHungarian}</td>" +
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
