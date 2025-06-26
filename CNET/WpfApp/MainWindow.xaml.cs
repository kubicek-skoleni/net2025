using System.Net.Http;
using System.Net.Http.Json;
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

namespace WpfApp
{
    public class CityInfo
    {
        public string City { get; set; }
        public int Count { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnTest_Click(object sender, RoutedEventArgs e)
        {
            var baseUrl = "https://localhost:7194";
            HttpClient client = new();
            client.BaseAddress = new Uri(baseUrl);

            var top20 = await client.GetFromJsonAsync<List<CityInfo>>("/city/top20");

            txbInfo.Text = "";

            foreach (var cityInfo in top20) 
            {
                txbInfo.Text += $"{cityInfo.City}: {cityInfo.Count} {Environment.NewLine}";
            }
        }
    }
}