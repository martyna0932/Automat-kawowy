using Project;
using System.Linq;
using System.Windows;

namespace CoffeeOrderApp

{
    public partial class LoginWindow : Window
    {
        
        public LoginWindow()
        {
            InitializeComponent();
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

            using (var db = new CoffeeDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
                if (user != null)
                {
                    MessageBox.Show($"Witaj, {user.UserName}!\nMasz {user.LoyaltyPoints} punktów.");

                    MainWindow main = new MainWindow();
                    main.Show();
                    main.LoggedUserId = user.Id; 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło.");
                }
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }







    }
 }
   

