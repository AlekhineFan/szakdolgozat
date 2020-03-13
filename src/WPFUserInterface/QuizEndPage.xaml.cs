using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFUserInterface
{
    /// <summary>
    /// Interaction logic for QuizEndPage.xaml
    /// </summary>
    public partial class QuizEndPage : Page
    {
        public event EventHandler Finished;

        public QuizEndPage()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }

    }
}
