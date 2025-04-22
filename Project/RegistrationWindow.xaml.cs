using CoffeeOrderApp;
using System;
using System.Windows;
using CoffeeOrderApp.Repositories;
using CoffeeOrderApp.Models;

namespace CoffeeOrderApp
{
    public partial class RegistrationWindow : Window
    {
        private readonly IUserRepository _userRepository;

        public RegistrationWindow()
        {
            InitializeComponent();
            _userRepository = new UserRepository(new CoffeeDbContext()); // można też wstrzyknąć przez konstruktor, jeśli chcesz
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string firstName = RegistrationNameTextBox.Text.Trim();
            string lastName = RegistrationSurnameTextBox.Text.Trim();
            string username = RegistrationUsernameTextBox.Text.Trim();
            string password = RegistrationPasswordBox.Password.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione.");
                return;
            }

            // Użycie repozytorium zamiast bezpośredniego dostępu do bazy
            var existingUser = _userRepository.GetUserByUsername(username);
            if (existingUser != null)
            {
                MessageBox.Show("Użytkownik o takiej nazwie już istnieje.");
                return;
            }

            var newUser = new User
            {
                Name = firstName,
                Surname = lastName,
                UserName = username,
                Password = password,
                Role = "User",
                LoyaltyPoints = 0
            };

            _userRepository.AddUser(newUser); // Dodajemy nową metodę do interfejsu i repo

            MessageBox.Show("Rejestracja zakończona sukcesem! Teraz możesz się zalogować.");

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
