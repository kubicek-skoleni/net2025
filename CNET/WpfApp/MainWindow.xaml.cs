using System.Buffers.Text;
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
using Model;

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
        private string baseUrl = "https://localhost:7194";
        private HttpClient client = new();
        

        public MainWindow()
        {
            InitializeComponent();

            client.BaseAddress = new Uri(baseUrl);
        }

        private async void btnTest_Click(object sender, RoutedEventArgs e)
        {
            var top20 = await client.GetFromJsonAsync<List<CityInfo>>("/city/top20");

            txbInfo.Text = "";

            foreach (var cityInfo in top20) 
            {
                txbInfo.Text += $"{cityInfo.City}: {cityInfo.Count} {Environment.NewLine}";
            }
        }

        private async void btnPersonDetail_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            bool result = int.TryParse(txtPersonID.Text, out id);

            if (!result)
            {
                txbInfo.Text = "Nepodařilo se převést ID na int";
                return;
            }

            var person =
                await client.GetFromJsonAsync<Person>($"/person/{id}");

            txbInfo.Text = "";

            txbInfo.Text =
                $"{person.FirstName} {person.LastName} {person.Email}";
        }
    }
}