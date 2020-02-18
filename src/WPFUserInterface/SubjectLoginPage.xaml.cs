using DataAccess.Model;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFUserInterface
{
    public partial class SubjectLoginPage : Page
    {
        public event EventHandler<Subject> Finished;
        public string SubjectName { get; set; }

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
                // TODO: validate name
                Subject subject = new Subject()
                {
                    Nickname = SubjectName,
                    Age = 20,
                    Gender = Gender.Female,
                    SessionStartDate = DateTime.Now
                };
                Finished?.Invoke(this, subject);
            }
        }
    }
}