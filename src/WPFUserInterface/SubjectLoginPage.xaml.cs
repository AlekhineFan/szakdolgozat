using DataAccess.Model;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFUserInterface
{
    public partial class SubjectLoginPage : Page
    {
        private readonly SubjectRepository subjectRepository = new SubjectRepository();

        public event EventHandler<Subject> Finished;
        public string SubjectName { get; set; }
        public Regex Regex { get; set; }

        public SubjectLoginPage()
        {
            InitializeComponent();
            DataContext = this;
            textBoxAge.Focus();
        }

        private void CreateSubject()
        {
            Regex = new Regex(@"^[a-zA-Z, áéíóöőúüű][a-zA-Z0-9 áéíóöőúüű]{5,19}$");

            if (!Regex.IsMatch(textBoxSubjectName.Text))
            {
                MessageBox.Show("A felhasználónév hossza 6 és 20 karakter közé kell, hogy essen! Csak kis- és nagybetűket, valamint számokat tartalmazhat, és nem kezdődhet számmal!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);

                textBoxSubjectName.Clear();
                return;
            }

            if (!(int.TryParse(textBoxAge.Text, out int age) && (age < 101 && age > 0)))
            {
                MessageBox.Show("Adjon megy egy érvényes életkort!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxAge.Clear();
                return;
            }

            Subject subject = new Subject()
            {
                Nickname = textBoxSubjectName.Text.Trim(),
                Age = Convert.ToInt32(textBoxAge.Text.Trim()),
                Gender = radioButtonMale.IsChecked == true ? Gender.Male : Gender.Female,
                SessionStartDate = DateTime.Now,
                QuestionAnswers = new List<QuestionAnswer>()
            };

            subjectRepository.Create(subject);
            Finished?.Invoke(this, subject);
        }

        private void TextBoxSubjectNameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CreateSubject();
            }
        }
        private void StartTest_Click(object sender, RoutedEventArgs e)
        {
            CreateSubject();
        }

        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            subjectRepository?.Dispose();
        }

        private void CancelTest_Click(object sender, RoutedEventArgs e)
        {
            textBoxAge.Clear();
            textBoxSubjectName.Clear();
            NavigationService.GoBack();
        }
    }
}