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
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Yeet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object propValue;
        Recipe reze=new Recipe(null,null,null,0,0,0,null,null);
        List<Recipe> liste_comp;
        int rad;

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
            Console.WriteLine("https://tasty.p.rapidapi.com/recipes/list?from=0&size=20&tags=" + getValueCb());
            FetchAsync(tes);
            if (liste_comp != null)
            {
                Window2 window2 = new Window2(liste_comp);
                window2.Show();
            }

        }

        private async Task FetchAsync(String tesca)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=40&tags=" + tesca.ToLower()),
                Headers =
    {
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
        { "x-rapidapi-key", "19a73fa3cemshcaef8b980b8f3dcp1803d1jsnfb013d66742a" },
    },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var resultatMoche = await response.Content.ReadAsStringAsync();
            Console.WriteLine("azer");
            JObject resultatEnObjet = JObject.Parse(resultatMoche);
            // l'array dans lequel chercher -> resultatEnObjet.SelectToken("results")
            //récupérer un objet dans l'array -> item.SelectToken("X") (X étant le champ recherché)
            liste_comp = reze.getList();
            liste_comp.Clear();
            foreach (var item in resultatEnObjet.SelectToken("results"))
            {
                string name = item.SelectToken("name").ToString();
                string image = item.SelectToken("thumbnail_url").ToString();
                string description = item.SelectToken("description").ToString();
                int duration=0;
                Console.WriteLine("azer");

                if (item.SelectToken("total_time_minutes") != null && item.SelectToken("total_time_minutes").ToString() != "")
                {
                    duration = item.SelectToken("total_time_minutes").ToObject<int>();
                }

                if (item.SelectToken("total_time_minutes") == null)
                {
                    duration = 0;
                }

                int score_positive=0;
                int score_negative = 0;

                if (item.SelectToken("user_ratings") != null)
                {
                    var itel = item.SelectToken("user_ratings");
                    JToken token = itel["count_positive"];
                    JToken toskan = itel["count_negative"];
                    if (token != null)
                    {
                        score_positive = (int)item.SelectToken("user_ratings").SelectToken("count_positive");
                    }
                    if (toskan != null)
                    {
                        score_positive = (int)item.SelectToken("user_ratings").SelectToken("count_negative");
                    }

                }
           
                List<String> crak = new List<string>();
                if (item.SelectToken("sections") != null)
                {
                    foreach (var itek in item.SelectToken("sections"))
                    {
                        foreach (var iteker in itek.SelectToken("components"))
                        {
                            string ingredients = iteker.SelectToken("raw_text").ToString();
                            crak.Add(ingredients);
                        }
                    }
                }

                List<String> crakas = new List<string>();
                if (item.SelectToken("instructions") != null)
                {
                    foreach (var itek in item.SelectToken("instructions"))
                    {
                        string instructions = itek.SelectToken("display_text").ToString();
                        crakas.Add(instructions);
                    }
                }

                Recipe dish = new Recipe(name, description, image, duration, score_positive, score_negative, crak, crakas);
                liste_comp.Add(dish);               
                /*foreach (var mem in crak)
                {
                    Console.WriteLine(mem.ToString());
                }
                foreach (var mem in crakas)
                {
                    Console.WriteLine(mem.ToString());
                }*/
                
                
            }
            foreach (var mem in liste_comp)
            {
                Console.WriteLine(mem.toString());
            }
        }

        private void GetValue(JObject resultatEnObjet)
        {
            throw new NotImplementedException();
        }
        public List<Recipe> getList()
        {
            return liste_comp;
        }
        public int getRad()
        {
            var rand = new Random();
            rad = rand.Next(10);
            return rad;
        }
        /*public void display(MainWindow mane,List<Recipe> lipe)
        {
            System.Windows.Forms.NotifyIcon klao = new System.Windows.Forms.NotifyIcon();
            var rand = new Random();
            PictureBox img = new PictureBox();
            lipe = liste_comp;
            //Recipe coca = clark.getList()[clark.getRad()];
            
            img.Load(lipe[rand.Next(0,50)].getImage());
        }*/
    }
}
