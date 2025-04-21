using CoffeeOrderApp;
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

namespace Project
{
    /// <summary>
    /// Logika interakcji dla klasy SwitchUser.xaml
    /// </summary>
    public partial class SwitchUser : Window
    {
        public SwitchUser()
        {
            InitializeComponent();
        }

        private void OrderHistory_Click(object sender, RoutedEventArgs e)
        {
            OrderHistoryWindow OrderHistoryWindow = new OrderHistoryWindow();  
            OrderHistoryWindow.Show();  
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
        private void User_Click(object sender, RoutedEventArgs e)
        {

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
    }
}
