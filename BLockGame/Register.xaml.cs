using System;
using System.Threading;
using System.Windows;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net;

using WpfMessageBox = System.Windows.MessageBox;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows; 
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Services;

using MongoDB.Bson;
using MongoDB.Driver;


namespace BLockGame
{
    public partial class Register : Window
    {

        private static IMongoCollection<BsonDocument> _collection;
        public Register()
        {
            InitializeComponent();

            var client = new MongoClient("mongodb+srv://fryyzihnk:TgBtqkuh70KbK6JX@clusteruser.rhkqo.mongodb.net/BLockGame?retryWrites=true&w=majority&appName=ClusterUser");
            var database = client.GetDatabase("BLockGame");

            _collection = database.GetCollection<BsonDocument>("User"); ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Gmail = GmailTextBox.Text;
            var Login = LoginTextBox.Text;
            var Password = PasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(Gmail))
            {
                WpfMessageBox.Show("Будь ласка введіть пошту!");
            }
            if (string.IsNullOrWhiteSpace(Login))
            {
                WpfMessageBox.Show("Введіть будь ласка свій логін");
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                WpfMessageBox.Show("Введіть будь ласка свій пароль");
            }
            else
            {
                try
                {
                    if(IsValidEmail(Gmail))
                    {
                        var document = new BsonDocument
                        {
                            {"Gmail", Gmail},
                            {"Login", Login},
                            {"Password", Password}
                        };

                        _collection.InsertOne(document);

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else{
                        WpfMessageBox.Show("введена пошта не коректна! Введіть будь ласка коректну пошту (Приклад test@example.com)");
                    }
                }
                catch
                {
                    WpfMessageBox.Show("Помилка не вталось створити аккаунт! Повторіть попитку пізніше");
                }
            }
        }

        static bool IsValidEmail(string email){

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try{
                var clientSecrets = new ClientSecrets
                {
                    
                };

                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientSecrets,
                    Scopes = new[] { "https://www.googleapis.com/auth/userinfo.email", "https://www.googleapis.com/auth/userinfo.profile" }
                });

                var codeReceiver = new LocalServerCodeReceiver();
                var credential = await new AuthorizationCodeInstalledApp(flow, codeReceiver)
                .AuthorizeAsync("user", CancellationToken.None);

                WpfMessageBox.Show($"Access Token: {credential.Token.AccessToken}", "Успішна авторизація");

                var peopleService = new PeopleServiceService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "GoogleAuthWpfApp"
                });

                var request = peopleService.People.Get("people/me");
                request.PersonFields = "names,emailAddresses";
                Person profile = await request.ExecuteAsync();

                string name = profile.Names?[0]?.DisplayName ?? "Імя не знайдено";
                string email = profile.EmailAddresses?[0]?.Value ?? "Улектрону пошту не знайденно";

                WpfMessageBox.Show($"Імя {name}\nEmail {email}", "Information in User");




            }
            catch(Exception ex){
                WpfMessageBox.Show($"Помилка авторицазії: {ex.Message}", "Помилка");
            }
        }
    }
}
