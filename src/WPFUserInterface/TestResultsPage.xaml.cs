using BusinessLogic;
using DataAccess.Model;
using HtmlStringToPdf;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFUserInterface
{
    public partial class TestResultsPage : Page
    {
        private SubjectManager subjectManager;
        private readonly LoadingScreenController loadingScreen;

        public object PdfGenerator { get; private set; }

        public TestResultsPage(LoadingScreenController loadingScreen)
        {
            InitializeComponent();
            this.loadingScreen = loadingScreen;
            SearchBox.Focus();
        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            subjectManager = new SubjectManager();
            var subjects = subjectManager
                .GetAllSubjects()
                .Include(subject => subject.QuestionAnswers)
                .ThenInclude(answer => answer.Question)
                .OrderBy(s => s.Nickname)
                .ToList();

            listBoxSubjects.ItemsSource = subjects;
        }

        private async void ButtonPdf_Click(object sender, RoutedEventArgs e)
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
            generator.HtmlProvider = new HtmlProvider(selectedSubject);
            string path = saveFileDialog.FileName;

            await loadingScreen.DoActionWhileLoadingScreenAsync(
                () => generator.WritePDF(path));

            MessageBox.Show($"Mentés sikeres:\n{path}", "Mentés kész", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ButtonPreviewPdf_Click(object sender, RoutedEventArgs e)
        {
            Subject selectedSubject = (Subject)listBoxSubjects.SelectedItem;
            if (selectedSubject == null)
                return;

            PreviewImageGenerator previewGenerator = new PreviewImageGenerator();
            previewGenerator.HtmlProvider = new HtmlProvider(selectedSubject);
            byte[] imageBytes = previewGenerator.ConvertHtmlToImage();

            Window previewWindow = new Window();
            previewWindow.PreviewKeyDown += (sender, e) =>
            {
                if (e.Key == Key.Escape)
                    previewWindow.Close();
            };
            previewWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            BitmapSource bitmapSource = (BitmapSource)new ImageSourceConverter().ConvertFrom(imageBytes);
            previewWindow.Content = new Image
            {
                Source = bitmapSource
            };

            previewWindow.Height = bitmapSource.Height;
            previewWindow.Width = bitmapSource.Width;
            previewWindow.ShowDialog();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchFor = SearchBox.Text.ToLower();
            var subjects = subjectManager
               .GetAllSubjects()
               .Include(subject => subject.QuestionAnswers)
               .ThenInclude(answer => answer.Question)
               .OrderBy(s => s.Nickname)
               .Where(s => s.Nickname.ToLower().StartsWith(searchFor))
               .ToList();

            listBoxSubjects.ItemsSource = subjects;
        }
    }
}