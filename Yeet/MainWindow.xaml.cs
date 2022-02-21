using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YeetClass;

namespace Yeet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public String getValueCb()
        {
            return cbBox.Text;
        }

        private void HandleSubmit(object sender, RoutedEventArgs e)
        {
            String tes = getValueCb();
            Console.WriteLine("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags="+getValueCb());
            this.FetchAsync(tes);
        }

        private async Task FetchAsync(String tesca)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags="+tesca.ToLower()),
                Headers = 
    {
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
        { "x-rapidapi-key", "19a73fa3cemshcaef8b980b8f3dcp1803d1jsnfb013d66742a" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var resultatMoche = await response.Content.ReadAsStringAsync();
                JObject resultatEnObjet = JObject.Parse(resultatMoche);
                //Console.WriteLine(resultatEnObjet.ToString());
                Console.WriteLine(resultatEnObjet.Path);
            }
        }
    }
}
