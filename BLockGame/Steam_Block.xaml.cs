using System.Net.Http;
using System.Windows;
using Newtonsoft.Json.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using WpfMessageBox = System.Windows.MessageBox;
using System.IO;
using System.Text.RegularExpressions;

using MongoDB.Driver;
using MongoDB.Bson;
using System.Net.NetworkInformation;

namespace BLockGame
{
    public partial class Team_Block : Window
    {
        private string[] Day = { "Понеділок", "Вівторок", "Середа", "Четверг", "П'ятниця", "Суббота", "Неділя" };

        private static IMongoCollection<BsonDocument> _collection;

        string apiKey = "1744EA18CBBFDCF855948A249C398F30";
        string steamId = "76561198961054657";

        private string GameDirectory = @"D:\Steam\steamapps\common\";

        private static string ItemComboBox;
        private static string StartText;
        private static string EndText;
        private static string FileName;
        private static string foldername;

        private List<string> gameNames = new();

        public Team_Block()
        {
            InitializeComponent();

            var client = new MongoClient("mongodb+srv://fryyzihnk:TgBtqkuh70KbK6JX@clusteruser.rhkqo.mongodb.net/BLockGame?retryWrites=true&w=majority&appName=ClusterUser");
            var database = client.GetDatabase("BLockGame");
            _collection = database.GetCollection<BsonDocument>("BlockUserGame");

            foreach (var day in Day)
            {
                DayComboBox.Items.Add(day);
            }

            LoadGamesAsync();
        }

        private async Task LoadGamesAsync()
        {
            string url = $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/?key={apiKey}&steamid={steamId}&include_appinfo=1";
            using HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync(url);

            string json = await response.Content.ReadAsStringAsync();
            JObject data = JObject.Parse(json);
            var games = data["response"]?["games"];

            if (games != null)
            {
                gameNames.Clear();
                foreach (var game in games)
                {
                    string gameName = game["name"]?.ToString();
                    if (!string.IsNullOrEmpty(gameName))
                    {
                        gameNames.Add(gameName);
                    }
                }
                ListSteamGame.ItemsSource = gameNames;
            }
        }

        private async Task<string> FindGameExecutableAsync(string gameName){
            return await Task.Run(() =>{
                try{
                    var directories = Directory.GetDirectories(GameDirectory);
                    foreach (var dir in directories)
                    {
                        if (Path.GetFileName(dir).ToLower().Contains(gameName.ToLower()))
                        {
                            var exeFiles = Directory.GetFiles(dir, "*.exe", SearchOption.AllDirectories);
                            if (exeFiles.Length > 0)
                                return exeFiles[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при пошуку: {ex.Message}");
                }
                return null;
            });
        }




        private void SearchGame_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchGame.Text.ToLower();

            var filteredGames = gameNames
                .Where(g => g.ToLower().Contains(searchText))
                .ToList();

            ListSteamGame.ItemsSource = filteredGames;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if(!string.IsNullOrEmpty(DayComboBox.SelectedItem.ToString()))
            {
                ItemComboBox = DayComboBox.SelectedItem.ToString();
                if(!string.IsNullOrEmpty(MinDay.Text)){
                     if(!string.IsNullOrEmpty(MaxDay.Text)){
                        StartText = MinDay.Text;
                        EndText = MaxDay.Text;

                        var Text = new BsonDocument
                        {
                            {"Id_Game", FileName},
                            {"Name_Game", foldername},
                            {"User", Base_User.User},
                            {"Day", ItemComboBox},
                            {"StartTime", StartText},
                            {"EndTime", EndText}
                        };
                        _collection.InsertOne(Text);
                     }
                     else{
                        WpfMessageBox.Show("Будь ласка виберіть час до якого програма буде працюати", "Помилка");
                     }
                }
                else{
                    WpfMessageBox.Show("Будь ласка введіть час з якого програма буде запускатися!", "Помилка");
                }

            }
            else{
                WpfMessageBox.Show("Виберіть будь ласка день в який програма буде запускатися!", "Помилка");
            }

        }

        private async void ListSteamGame_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListSteamGame.SelectedItem != null)
            {
                string selectedGame = ListSteamGame.SelectedItem.ToString();

                string foundPath = await FindGameExecutableAsync(selectedGame);
                foldername = foundPath;


                if (!string.IsNullOrEmpty(foundPath))
                {
                    string fileName = Path.GetFileName(foundPath);
                    FileName = fileName;
                    //System.Windows.Clipboard.SetText(fileName);

                    WpfMessageBox.Show($"Знайдено та добавленно: {fileName}", "✅ Успіх");
                }
                else
                {
                    WpfMessageBox.Show("Файл гри не знайдено", "❌ Помилка");
                }
            }
        }

        private void ListSteamGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
