using DataAccess.Model;
using DataAccess.Repositories;
using System;
using System.Linq;

namespace BusinessLogic
{
    public class QuizMaster : IDisposable
    {
        private readonly QuestionManager questionManager = new QuestionManager();
        private readonly SubjectRepository subjectRepository = new SubjectRepository();

        private readonly Subject subject;
        private readonly Question[] questions;
        private int currentQuestionIndex = -1;
        private Question CurrentQuestion => questions[currentQuestionIndex];

        public QuizMaster(Subject subject)
        {
            if (subject is null)
                throw new ArgumentNullException(nameof(subject));

            this.subject = subject;
            questions = questionManager.GetQuestionsForSubject(subject).ToArray();
        }

        public Question GetNextQuestion()
        {
            if (currentQuestionIndex >= questions.Length)
                return null;

            currentQuestionIndex++;
            if (currentQuestionIndex >= questions.Length)
                return null;

            Question current = CurrentQuestion;
            return current;
        }

        public void AddAnswer(bool answer)
        {
            QuestionAnswer questionAnswer = new QuestionAnswer
            {
                Question = CurrentQuestion,
                Answer = answer
            };

            subject.QuestionAnswers.Add(questionAnswer);
        }

        public void SaveAnswers()
        {
            subjectRepository.Update(subject);
        }

        public void Dispose()
        {
            questionManager?.Dispose();
            subjectRepository?.Dispose();
        }
    }
}