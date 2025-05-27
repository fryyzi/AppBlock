using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Squirrel;


namespace TestUpdate    
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _ = AutoCheckForUpdates(); // Перевірка при старті
        }

        private async Task AutoCheckForUpdates()
        {
            StatusText.Text = "Перевірка оновлень...";
            bool updated = await CheckForUpdates();
            if (updated)
                MessageBox.Show("Знайдено та встановлено оновлення! Перезапустіть програму.");
            else
                StatusText.Text = "Оновлень не знайдено.";
        }
        private async void CheckUpdate_Click(object sender, RoutedEventArgs e)
        {
            StatusText.Text = "Перевірка оновлень...";
            bool updated = await CheckForUpdates();
            if (updated)
                MessageBox.Show("Оновлення встановлено! Перезапустіть програму.");
            else
                MessageBox.Show("Оновлень не знайдено.");
        }
        private async Task<bool> CheckForUpdates()
        {
            try
            {
                // 🔁 Заміни на свій GitHub репозиторій (з .nupkg і RELEASES)
                using (var manager = await UpdateManager.GitHubUpdateManager("https://github.com/yourusername/yourrepo"))
                {
                    var release = await manager.Result.UpdateApp();
                    return release != null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка оновлення: {ex.Message}");
                return false;
            }
        }
    }
}