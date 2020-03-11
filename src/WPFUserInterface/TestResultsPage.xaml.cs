using BusinessLogic;
using DataAccess.Model;
using HtmlStringToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFUserInterface
{
    /// <summary>
    /// Interaction logic for TestResultsPage.xaml
    /// </summary>
    public partial class TestResultsPage : Page
    {
        private SubjectManager subjectManager;

        public object PdfGenerator { get; private set; }

        public TestResultsPage()
        {
            InitializeComponent();
        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            subjectManager = new SubjectManager();
            var subjects = subjectManager.GetAllSubjects().ToList();
            listBoxSubjects.ItemsSource = subjects;
        }

        private void buttonPdf_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxSubjects.SelectedItem == null)
                return;
            PdfGenerator generator = new PdfGenerator();
            Subject selectedSubject = (Subject)listBoxSubjects.SelectedItem;
            generator.WritePDF(selectedSubject);
        }
    }
}
