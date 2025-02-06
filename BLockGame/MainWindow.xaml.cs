using System;
using System.Windows;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Windows.Input;
using DnsClient;


using WinFormsMessageBox = System.Windows.Forms.MessageBox;
using WpfMessageBox = System.Windows.MessageBox;


using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Services;

using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.VisualBasic.ApplicationServices;



namespace BLockGame
{
    public partial class MainWindow : Window
    {

        private static IMongoCollection<BsonDocument> _collection;
        Main_Manu main_Manu = new Main_Manu();



        string login;
        string password;
        string Name;
        string Email;
        string User;

        public MainWindow()
        {
            InitializeComponent();

            var client = new MongoClient("mongodb+srv://fryyzihnk:TgBtqkuh70KbK6JX@clusteruser.rhkqo.mongodb.net/BLockGame?retryWrites=true&w=majority&appName=ClusterUser");
            var database = client.GetDatabase("BLockGame");

            _collection = database.GetCollection<BsonDocument>("User");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
            var EnterLogin = MyLoginBox.Text;
            var EnterPassword = MyPasswordBox.Password;

            var allUsers = _collection.Find(new BsonDocument()).ToList();

            foreach (var user in allUsers)
            {
                login = user["Login"].ToString();
                password = user["Password"].ToString();
                if (EnterLogin == login)
                {
                    if (EnterPassword == password)
                    {
                        Main_Manu main_Manu = new Main_Manu();
                        Base_User.User = EnterLogin;

                        main_Manu.Show();
                        this.Close();
                        return;
                    }
                    if (EnterPassword != password)
                    {
                        WpfMessageBox.Show("Не вірний пароль! Повторіть попитку");
                    }
                }
            }
            if(EnterLogin != login && EnterPassword == password){
                WpfMessageBox.Show("Не вірний логин! Будь ласка повторіть попитку!");
            }
            if (EnterLogin != login && EnterPassword != password) {
                WpfMessageBox.Show("Не вірний логін та пароль! Повторіть попитку!");
            }
            
        }

        private void Register_Click(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Show();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var clientSecrets = new ClientSecrets
                {
                    ClientId = "490119776031-et6qj831qvg1ci7tp8sko7qjv0uuq9nn.apps.googleusercontent.com",
                    ClientSecret = "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"
                };

                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientSecrets,
                    Scopes = new[] { "https://www.googleapis.com/auth/userinfo.email", "https://www.googleapis.com/auth/userinfo.profile" }
                });

                var codeReceiver = new LocalServerCodeReceiver();
                var credential = await new AuthorizationCodeInstalledApp(flow, codeReceiver)
                .AuthorizeAsync("user", CancellationToken.None);

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

                var allUsers = _collection.Find(new BsonDocument()).ToList();


                string Email = string.Empty;

                foreach (var user in allUsers)
                {
                    if (user.Contains("Email") && user["Email"] != null)
                    {
                        Email = user["Email"].ToString();
                    }
                }

                if (email.Equals(Email, StringComparison.OrdinalIgnoreCase))
                {
                    Base_User.User = name;
                    main_Manu.Show();
                    this.Close();
                }
                else if (email != Email)
                {
                    var User = new BsonDocument
                    {
                        {"Login", name},
                        {"Email", email},
                    };
                    _collection.InsertOne(User);
                    Base_User.User = name;
                    main_Manu.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                WpfMessageBox.Show($"Помилка авторицазії: {ex.Message}", "Помилка");
            }
        }
    }
}
