using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Globalization;


using WinFormsApp = System.Windows.Forms.Application;
using WpfApp = System.Windows.Application;
using WpfMessageBox = System.Windows.MessageBox;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Media;


namespace BLockGame
{
    public partial class Main_Manu : Window
    {


        private NotifyIcon trayIcon;

        string IdProgram;
        string NicknameUser;
        string StartTime = "0";
        string EndTime = "0";
        string Day;
        int IntStartTime;
        int IntEndTime;


        string NicknameUserEmail;
        string UserGmail;

        string FileCode = "3122312d2-odm0if3jf3ur0fjmrr033rc";
        string ViewFileCOde = string.Empty;
        string FileText = string.Empty;

        DateTime now = DateTime.Now;
        CultureInfo culture = new CultureInfo("uk-UA");


        private static IMongoCollection<BsonDocument> _collectionGame;
        private static IMongoCollection<BsonDocument> _collectionUser;
        
        public Main_Manu()
        {
            InitializeComponent();

            if(Base_User.IsAutotization){
                trayIcon = new NotifyIcon
                {

                    Icon = new Icon(SystemIcons.Application, 40, 40),
                    Text = "BlockGame",
                    Visible = true,
                    ContextMenuStrip = new ContextMenuStrip()
                };

                trayIcon.ContextMenuStrip.Items.Add("Відкрити ", null, OpenApp);
                trayIcon.ContextMenuStrip.Items.Add("Закрити", null, ExitApp);

                this.Closing += Windows_Closing;
            }

            //Ліцензія
            FileText = File.ReadAllText("F:\\programing\\Project\\Block Game\\BLockGame\\BLockGame\\bin\\Debug\\net8.0-windows\\Code.txt");
            if(FileText == FileCode){
                DeleteApp.IsEnabled = false;
                DeleteApp.Foreground = new SolidColorBrush(Colors.Black);
            }

            //Підключення до бд
            var client = new MongoClient("mongodb+srv://fryyzihnk:TgBtqkuh70KbK6JX@clusteruser.rhkqo.mongodb.net/BLockGame?retryWrites=true&w=majority&appName=ClusterUser");
            var database = client.GetDatabase("BLockGame");


            _collectionGame = database.GetCollection<BsonDocument>("BlockUserGame");
            _collectionUser = database.GetCollection<BsonDocument>("User");
            var GameBlock = _collectionGame.Find(new BsonDocument()).ToList();
            var User = _collectionUser.Find(new BsonDocument()).ToList();

            foreach (var item in GameBlock)
            {
                IdProgram = item["Id_Game"].ToString();
                NicknameUserEmail = item["User"].ToString();
                StartTime = item["StartTime"].ToString();
                EndTime = item["EndTime"].ToString();
                Day = item["Day"].ToString();

            };
            foreach (var user in User){
                NicknameUser = user["Login"].ToString();
            }

            

            string gameFolderPath = @"null";

            

            IntStartTime = int.Parse(StartTime);
            IntEndTime = int.Parse(EndTime);

            Task.Run(() => MonitorGameStatus(IdProgram, IntStartTime, IntEndTime, Day));
        }

        private void MonitorGameStatus(string IdProgram, int StartTime, int EndTime, string Day )
        {
            string dayOfWeekUkrainian = now.ToString("dddd", culture);
            if (Base_User.User == NicknameUserEmail)
            {
                if(now.Hour >= StartTime && now.Hour < EndTime){
                    if (dayOfWeekUkrainian.Equals(Day, StringComparison.OrdinalIgnoreCase)){
                        return;
                    }
                }
                else{
                    while (true)
                    {
                        if (IsGameRunning(IdProgram))
                        {
                            CloseGame(IdProgram);
                        }
                        Thread.Sleep(5000);
                    }
                }
            }
        }
        static bool IsGameRunning(string gameExeName)
        {
            Process[] processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                if (process.ProcessName.Equals(Path.GetFileNameWithoutExtension(gameExeName), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        static void CloseGame(string gameExeName)
        {
            Process[] processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                if (process.ProcessName.Equals(Path.GetFileNameWithoutExtension(gameExeName), StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        process.Kill();
                        Console.WriteLine($"Процес {gameExeName} був успішно завершений.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Не вдалося закрити процес {gameExeName}: {ex.Message}");
                    }
                }
            }
        }


        private void Windows_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            trayIcon.ShowBalloonTip(1000, "Програма згорнута", "Програма працює у фоновому режимі", ToolTipIcon.Info);
        }

        private void OpenApp(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
        }

        private void ExitApp(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            trayIcon.Dispose();
            WpfApp.Current.Shutdown();
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window_Block_Game window_Block_Game = new Window_Block_Game();
            window_Block_Game.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            License license = new License();
            license.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}
