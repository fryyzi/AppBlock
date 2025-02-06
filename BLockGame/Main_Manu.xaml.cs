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


namespace BLockGame
{
    /// <summary>
    /// Логика взаимодействия для Main_Manu.xaml
    /// </summary>
    ///
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

        DateTime now = DateTime.Now;
        CultureInfo culture = new CultureInfo("uk-UA");


        private static IMongoCollection<BsonDocument> _collectionGame;
        private static IMongoCollection<BsonDocument> _collectionUser;
        
        public Main_Manu()
        {
            InitializeComponent();


            trayIcon = new NotifyIcon
            {

                Icon = new Icon(SystemIcons.Application, 40, 40),
                Text = "BlockGame",
                Visible = true,
                ContextMenuStrip = new ContextMenuStrip()
            };

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

            trayIcon.ContextMenuStrip.Items.Add("Відкрити ", null, OpenApp);
            trayIcon.ContextMenuStrip.Items.Add("Закрити", null, ExitApp);

            string gameFolderPath = @"null";

            this.Closing += Windows_Closing;

            IntStartTime = int.Parse(StartTime);
            IntEndTime = int.Parse(EndTime);

            Task.Run(() => MonitorGameStatus(IdProgram, IntStartTime, IntEndTime, Day));
        }

        private void MonitorGameStatus(string IdProgram, int StartTime, int EndTime, string Day )
        {
            string dayOfWeekUkrainian = now.ToString("dddd", culture);
            if (Base_User.User == NicknameUser)
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
            UnBlock unBlock = new UnBlock();
            unBlock.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}
