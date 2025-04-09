using CoffeeOrderApp;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CoffeeOrderApp
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }



        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Pobranie danych z formularza
            string firstName = RegistrationNameTextBox.Text.Trim();
            string lastName = RegistrationSurnameTextBox.Text.Trim();
            string username = RegistrationUsernameTextBox.Text.Trim();
            string password = RegistrationPasswordBox.Password.Trim();

            // Walidacja pól
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione.");
                return;
            }



            // Sprawdzenie, czy użytkownik już istnieje
            using (var db = new CoffeeDbContext())
            {


                if (db.Users.Any(u => u.UserName == username))
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

                db.Users.Add(newUser);
                db.SaveChanges();

                MessageBox.Show("Rejestracja zakończona sukcesem! Teraz możesz się zalogować.");


                this.Close();
            }
        }

           private void Back_Click(object sender, RoutedEventArgs e)
           {

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
             }
    }
        
    
}
