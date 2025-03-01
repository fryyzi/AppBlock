using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using WPF = System.Windows.MessageBox;

namespace BLockGame
{
    public partial class License : Window
    {

        string LicenseTextUser = "";
        string LicenseText = "38fh92d2eh2fu92ed92ufh2euf2efu92efh2fjk2f";
        public License()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LicenseTextUser = TextBoxKey.Text;

            if(LicenseText == LicenseTextUser)
            {
                UnBlock unBlock = new UnBlock();
                unBlock.Show();
                this.Close();
                WPF.Show("Ключь успішло настосований!");
            }
            else{
                Main_Manu mainWindow = new Main_Manu();
                mainWindow.Show();
                this.Close();
                WPF.Show("Не вірний ключь");
            }

            
        }
    }
}
