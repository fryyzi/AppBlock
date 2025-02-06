using System;
using System.Windows;


using WinFormsApp = System.Windows.Forms.Application;
using WpfApp = System.Windows.Application;
using WpfMessageBox = System.Windows.MessageBox;


using MongoDB.Bson;
using MongoDB.Driver;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BLockGame
{
    public partial class Window_Block_Game : Window
    {

        private string[] Day = { "Понеділок", "Вівторок", "Середа", "Четверг", "П'ятниця", "Суббота", "Неділя" };

        private static IMongoCollection<BsonDocument> _collection;

        private static string ItemComboBox;
        private static string StartText;
        private static string EndText;

        string GetEmailDataBAse;
        string GetUserName;
        public Window_Block_Game()
        {
            InitializeComponent();
            var client = new MongoClient("mongodb+srv://fryyzihnk:TgBtqkuh70KbK6JX@clusteruser.rhkqo.mongodb.net/BLockGame?retryWrites=true&w=majority&appName=ClusterUser");
            var database = client.GetDatabase("BLockGame");

            _collection = database.GetCollection<BsonDocument>("BlockUserGame");

            foreach (var day in Day)
            {
                DayComboBox.Items.Add(day);
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Id_Game.Text))
            {
                if (!string.IsNullOrEmpty(NameBlockGameTextBox.Text))
                {
                    string IdGame = Id_Game.Text;
                    string NameBlockGame = NameBlockGameTextBox.Text;

                    if (!string.IsNullOrEmpty(DayComboBox.SelectedItem?.ToString()))
                    {
                        ItemComboBox = DayComboBox.SelectedItem.ToString();
                        if (!string.IsNullOrEmpty(StartTimeTextBox.Text))
                        {
                            if(!string.IsNullOrEmpty(EndTimeTextBox.Text)) {

                                StartText = StartTimeTextBox.Text;
                                EndText = EndTimeTextBox.Text;
                                var Block = new BsonDocument
                                {
                                    {"Id_Game", IdGame},
                                    {"Name_Game", NameBlockGame},
                                    {"User", Base_User.User},
                                    {"Day",  ItemComboBox},
                                    {"StartTime", StartText},
                                    {"EndTime", EndText}
                                };
                                _collection.InsertOne(Block);
                            }
                           else{
                                WpfMessageBox.Show("Введіть час до якого хочете грати");
                           }
                        }
                        else{
                            WpfMessageBox.Show("Введіть час з якого хочете почати грати");
                        }
                    }
                    else{
                        WpfMessageBox.Show("Виберіть день в який хочете грати");
                    }
                }
                else{
                    WpfMessageBox.Show("Введіть назву програми яку хочете заблокувати");
                }
            }
            else
            {
                WpfMessageBox.Show("Введіть назву програми .exe");
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Main_Manu main_Manu = new Main_Manu();
            main_Manu.Show();
            this.Close();
        }

        private void TimeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            EndTimeTextBox.Visibility = Visibility.Visible;
            StartTimeTextBox.Visibility = Visibility.Visible;
            StartLable.Visibility = Visibility.Visible;
            EndLable.Visibility = Visibility.Visible;
            TextTimeInfo.Visibility = Visibility.Visible;
        }

        private void TimeCheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            EndTimeTextBox.Visibility = Visibility.Hidden;
            StartTimeTextBox.Visibility = Visibility.Hidden;
            StartLable.Visibility = Visibility.Hidden;
            EndLable.Visibility = Visibility.Hidden;
            TextTimeInfo.Visibility = Visibility.Hidden;
        }
    }
}
