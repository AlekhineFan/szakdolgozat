using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFUserInterface
{
    public partial class SubjectLoginPage : Page
    {
        public event EventHandler<string> Finished;
        public string SubjectName { get; set; }

        public SubjectLoginPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void TextBoxSubjectNameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // TODO: validate name
                Finished?.Invoke(this, SubjectName);
            }
        }
    }
}