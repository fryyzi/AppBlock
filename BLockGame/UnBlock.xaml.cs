using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using WpfMessageBox = System.Windows.MessageBox;

namespace BLockGame
{
    /// <summary>
    /// Interaction logic for UnBlock.xaml
    /// </summary>
    public partial class UnBlock : Window
    {

        private static IMongoCollection<BsonDocument> _collection;

        private static string FindNameProgramDataBase;
        private static string DeleteTextBox;
        public UnBlock()
        {
            InitializeComponent();


            var client = new MongoClient("mongodb+srv://fryyzihnk:TgBtqkuh70KbK6JX@clusteruser.rhkqo.mongodb.net/BLockGame?retryWrites=true&w=majority&appName=ClusterUser");
            var database = client.GetDatabase("BLockGame");

            _collection = database.GetCollection<BsonDocument>("BlockUserGame");
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var NameProgram = _collection.Find(new BsonDocument()).ToList();

            foreach (var item in NameProgram) 
            {
                FindNameProgramDataBase = item["Name_Game"].ToString();
                DataTextBox.Text = FindNameProgramDataBase;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(DeleteTextBox)){
                WpfMessageBox.Show("Вви не ввели назву програми яку хочете видалити!");
            }
            else{
                DeleteTextBox = DeteleAppTextBox.Text;
                var filter = Builders<BsonDocument>.Filter.Eq("Name_Game", DeleteTextBox);

                _collection.DeleteOne(filter);
                this.Close();
            }
        }
    }
}

