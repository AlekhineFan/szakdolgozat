using DataAccess.Model;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class QuizMaster
    {
        private readonly IEnumerator<Question> questionsEnumerator;
        private readonly QuestionManager questionManager = new QuestionManager();
        private readonly QuestionAnswerRepository questionAnswerRepository = new QuestionAnswerRepository();
        private List<QuestionAnswer> questionAnswers = new List<QuestionAnswer>();

        public QuizMaster(Subject subject)
        {
            if (subject is null)
                throw new ArgumentNullException(nameof(subject));

            questionsEnumerator = questionManager.GetQuestionsForSubject(subject).GetEnumerator();
        }

        public Question GetNextQuestion()
        {
            questionsEnumerator.MoveNext();
            return questionsEnumerator.Current;
        }

        public void AddAnswer(Question question, bool answer)
        {
            QuestionAnswer questionAnswer = new QuestionAnswer
            {
                Question = question,
                Answer = answer
            };
            questionAnswers.Add(questionAnswer);
        }

        public void SaveAnswers()
        {
            questionAnswerRepository.SaveAnswers(questionAnswers);
        }
    }
}