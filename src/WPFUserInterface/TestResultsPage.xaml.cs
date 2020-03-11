using BusinessLogic;
using DataAccess.Model;
using HtmlStringToPdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPFUserInterface
{
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
            var subjects = subjectManager
                .GetAllSubjects()
                .Include(subject => subject.QuestionAnswers)
                .ThenInclude(answer => answer.Question)
                .ToList();

            listBoxSubjects.ItemsSource = subjects;
        }

        private void buttonPdf_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxSubjects.SelectedItem == null)
                return;

            Subject selectedSubject = (Subject)listBoxSubjects.SelectedItem;
            string fileName = $"{selectedSubject.Nickname} - {selectedSubject.SessionStartDate.ToString("yyyy-MM-dd HH.mm.ss")}";

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                CheckPathExists = true,
                DefaultExt = "pdf",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                ValidateNames = true,
                Filter = "PDF|*.pdf"
            };

            saveFileDialog.FileName = fileName;

            bool? result = saveFileDialog.ShowDialog();
            if (result != true)
                return;

            PdfGenerator generator = new PdfGenerator();
            string path = saveFileDialog.FileName;
            generator.WritePDF(selectedSubject, path);

            MessageBox.Show($"Mentés sikeres:\n{path}", "Mentés kész", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}