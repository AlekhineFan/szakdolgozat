using BusinessLogic;
using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using ScatterPoint = LiveCharts.Defaults.ScatterPoint;

namespace WPFUserInterface
{
    public partial class ChartPage : Page, INotifyPropertyChanged
    {
        public SeriesCollection SeriesCollection { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private ChartDataProvider chartDataProvider;

        public ChartPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            chartDataProvider = new ChartDataProvider();
            ChartData chartData = chartDataProvider.GetChartData();

            ScatterPoint[] malePoints = chartData.MaleScatterPoints
                .Select(p => new ScatterPoint(p.Percentage, p.Age, p.Weight))
                .ToArray();

            ScatterPoint[] femalePoints = chartData.FemaleScatterPoints
                .Select(p => new ScatterPoint(p.Percentage, p.Age, p.Weight))
                .ToArray();

            SeriesCollection = new SeriesCollection
            {
                new ScatterSeries
                {
                    Title= "Férfi",
                    PointGeometry = DefaultGeometries.Circle,
                    MinPointShapeDiameter = 15,
                    MaxPointShapeDiameter = 45,
                    Values = new ChartValues<ScatterPoint>(malePoints)
                },
                new ScatterSeries
                {
                    Title = "Nő",
                    PointGeometry = DefaultGeometries.Triangle,
                    MinPointShapeDiameter = 15,
                    MaxPointShapeDiameter = 45,
                    Values = new ChartValues<ScatterPoint>(femalePoints)
                },
            };
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SeriesCollection)));
        }
    }
}