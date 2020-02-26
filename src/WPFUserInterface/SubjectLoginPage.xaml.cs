﻿using DataAccess.Model;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFUserInterface
{
    public partial class SubjectLoginPage : Page
    {
        private readonly SubjectRepository subjectRepository = new SubjectRepository();

        public event EventHandler<Subject> Finished;
        public string SubjectName { get; set; } = "Subject123";
        public Regex Regex { get; set; }

        public SubjectLoginPage()
        {
            InitializeComponent();
            DataContext = this;
            textBoxSubjectName.Focus();
        }

        private void TextBoxSubjectNameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]{5,19}$");

                if (!Regex.IsMatch(textBoxSubjectName.Text)) //TODO: message box, excepton töröl
                    throw new ArgumentException("A felhasználónév hossza 6 és 20 karakter közé kell, hogy essen! Csak kis- és nagybetűket, valamint számokat tartalmazhat, és nem kezdődhet számmal!");

                Subject subject = new Subject() //TODO: Property értékek
                {
                    Nickname = SubjectName,
                    Age = 20,
                    Gender = Gender.Female,
                    SessionStartDate = DateTime.Now,
                    QuestionAnswers = new List<QuestionAnswer>()
                };

                subjectRepository.Create(subject);
                Finished?.Invoke(this, subject);
            }
        }

        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            subjectRepository?.Dispose();
        }
    }
}