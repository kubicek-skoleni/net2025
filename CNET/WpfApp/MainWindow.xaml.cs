using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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

        private List<string> LoadFiles()
        {
            string dir = @"C:\PROJECTS\skoleni2025\github\net2025\bigfiles";

            List<string> files = Directory.EnumerateFiles(dir, "*.txt")
                                         .ToList();

            return files;
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

        private void btnFiles_Click(object sender, RoutedEventArgs e)
        {
            string dir = @"C:\PROJECTS\skoleni2025\github\net2025\bigfiles";

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            List<string> files = Directory.EnumerateFiles(dir, "*.txt")
                                          .ToList();

            txbInfo.Text = "";

            foreach (var file in files)
            {
                Task.Delay(500).Wait();
                var lines = File.ReadLines(file).ToArray();
                var count = lines.Count();

                txbInfo.Text += $"{file} : {count} {Environment.NewLine} ";
            }

            stopwatch.Stop();
            txbInfo.Text += $"elapsed ms: {stopwatch.ElapsedMilliseconds}";
        }

        private void btnProcessFilesAll_Click(object sender, RoutedEventArgs e)
        {
            /*
               10 nejcastejsich slov celkem ve všech souborech - globálně
            */

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            txbInfo.Text = "";

            Dictionary<string, int> stats = new();

            var files = LoadFiles();

            foreach (var file in files)
            {
                var words = File.ReadLines(file);

                foreach (var word in words)
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.Add(word, 1);
                }
            }

            var top10 = stats.OrderByDescending(x => x.Value).Take(10);

            foreach (var word_kv in top10)
            {
                txbInfo.Text += $"{word_kv.Key}: {word_kv.Value} {Environment.NewLine}";
            }

            stopwatch.Stop();
            txbInfo.Text += $"elapsed ms: {stopwatch.ElapsedMilliseconds}";

            Mouse.OverrideCursor = null;
        }

        private void btnProcessPerFile_Click(object sender, RoutedEventArgs e)
        {
            /*
               10 nejcastejsich slov v kazdem souboru => 10 x statistika
            */

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            txbInfo.Text = "";

            var files = LoadFiles();

            foreach (var file in files)
            {
                Dictionary<string, int> stats = new ();

                foreach (var word in System.IO.File.ReadLines(file))
                {
                    if (stats.ContainsKey(word))
                        stats[word]++;
                    else
                        stats.Add(word, 1);
                }

                txbInfo.Text += file + Environment.NewLine;
                //txbResultsInfo.Text += Environment.NewLine;
                txbInfo.Text += string.Join(Environment.NewLine, stats.OrderByDescending(x => x.Value).Take(10)
                                            .Select(x => x.Key + ": " + x.Value));

                txbInfo.Text += Environment.NewLine + Environment.NewLine;
            }

            stopwatch.Stop();
            txbInfo.Text += $"elapsed ms: {stopwatch.ElapsedMilliseconds}";
            Mouse.OverrideCursor = null;
        }

        private async void btnAsyn1AllFiles_Click(object sender, RoutedEventArgs e)
        {
            /*
               10 nejcastejsich slov ve všech souborech globálně NEBLOKUJICIM
                asynchronnim zpusobem
            */

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            txbInfo.Text = "";

            var result = await Task.Run(() => FileProcessing.StatsAllFiles());

            foreach (var word_kv in result)
            {
                txbInfo.Text += $"{word_kv.Key}: {word_kv.Value} {Environment.NewLine}";
            }

            stopwatch.Stop();
            txbInfo.Text += $"elapsed ms: {stopwatch.ElapsedMilliseconds}";
            Mouse.OverrideCursor = null;
        }

        private void btnRandomColor_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            // Get the button that was clicked
            Button button = sender as Button;

            if (button != null)
            {
                // Generate random RGB values
                byte r = (byte)random.Next(256);
                byte g = (byte)random.Next(256);
                byte b = (byte)random.Next(256);

                // Create a new SolidColorBrush with the random color
                button.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            }
        }

        //Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
        //var stopwatch = new Stopwatch();
        //stopwatch.Start();
        //txbInfo.Text = "";

        //stopwatch.Stop();
        //txbInfo.Text += $"elapsed ms: {stopwatch.ElapsedMilliseconds}";
        //Mouse.OverrideCursor = null;
    }
}