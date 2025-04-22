using System.Windows;
using CoffeeOrderApp.Repositories;
using CoffeeOrderApp.Models;
using Project;

namespace CoffeeOrderApp
{
    public partial class LoginWindow : Window
    {
        private readonly IUserRepository _userRepository;

        public LoginWindow()
        {
            InitializeComponent();
            _userRepository = new UserRepository(new CoffeeDbContext());
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wprowadź nazwę użytkownika i hasło.");
                return;
            }

            var user = _userRepository.GetUserByCredentials(username, password);
            if (user != null)
            {
                MessageBox.Show($"Witaj, {user.UserName}!\nMasz {user.LoyaltyPoints} punktów.");

                StartWindow startwindow = new StartWindow();
                startwindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło.");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SwitchUser switchUser = new SwitchUser();
            switchUser.Show();
            this.Close();
        }
    }
}
