using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Windows.Media;
using Project;

namespace CoffeeOrderApp
{
    public partial class MainWindow : Window
    {
        public int LoggedUserId { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CoffeeViewModel();
            using (var db = new CoffeeDbContext())
            {
                db.Database.EnsureCreated();
            }
           
        }
     
        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as CoffeeViewModel;

            if (viewModel != null)
            {
                
                var order = new Order
                {
                    Coffee = viewModel.SelectedCoffee,
                    Milk = viewModel.SelectedMilk,
                    Syrup = viewModel.SelectedSyrup,
                    Price = viewModel.TotalPrice,
                    OrderDate = DateTime.Now,
                    UserId = 1 
                };

                int earnedPoints = viewModel.EarnedPoints;

                using (var dbContext = new CoffeeDbContext())
                {
                    dbContext.Orders.Add(order);

                  var user = dbContext.Users.FirstOrDefault(u => u.Id == LoggedUserId);
                    if (user != null)
                    {
                        user.LoyaltyPoints += earnedPoints; 
                    }

                   dbContext.SaveChanges();
                }


                MessageBox.Show($"Zamówienie: {order.Coffee}, {order.Milk}, {order.Syrup}\nCena: {order.Price:C2}\nZyskane punkty: {earnedPoints}", "Potwierdzenie zamówienia");
            }

            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
        
    }

    public class CoffeeViewModel : INotifyPropertyChanged
    {
        private string _selectedCoffee;
        private string _selectedMilk;
        private string _selectedSyrup;
        private string _selectedUser;
        private decimal _totalPrice;
        private string _coffeeImage;
        private int _earnedPoints;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> Coffees { get; set; } = new List<string>();
        public List<string> Milks { get; set; } = new List<string>();
        public List<string> Syrups { get; set; } = new List<string>();
        public List<string> User { get; set; } = new List<string>();

        public string SelectedCoffee
        {
            get => _selectedCoffee;
            set { _selectedCoffee = value; UpdatePriceAndImage(); NotifyPropertyChanged("SelectedCoffee"); }
        }

        public string SelectedMilk
        {
            get => _selectedMilk ?? "None";
            set { _selectedMilk = value; UpdatePriceAndImage(); NotifyPropertyChanged("SelectedMilk"); }
        }

        public string SelectedSyrup
        {
            get => _selectedSyrup ?? "None";
            set { _selectedSyrup = value; UpdatePriceAndImage(); NotifyPropertyChanged("SelectedSyrup"); }
        }

        public string SelectedUser
        {
            get => _selectedUser ?? "Gość";
            set { _selectedUser = value; UpdatePriceAndImage(); NotifyPropertyChanged("SelectedUser"); }
        }

        public decimal TotalPrice
        {
            get => _totalPrice;
            set { _totalPrice = value; NotifyPropertyChanged("TotalPrice"); }
        }
        public int EarnedPoints
        {
            get => _earnedPoints;
            set { _earnedPoints = value; NotifyPropertyChanged("EarnedPoints"); }
        }


        public string CoffeeImage
        {
            get => _coffeeImage;
            set 
            {
                if (_coffeeImage != value)
                {
                    _coffeeImage = value;
                    NotifyPropertyChanged("CoffeeImage");
                }
            }
        }

        public CoffeeViewModel()
        {
            LoadUserChoices();
        }

        private void LoadUserChoices()
        {
            Coffees.Add("Espresso");
            Coffees.Add("Latte");
            Coffees.Add("Cappuccino");
            Milks.Add("None");
            Milks.Add("Regular");
            Milks.Add("Oat");
            Milks.Add("Almond");
            Syrups.Add("None");
            Syrups.Add("Vanilla");
            Syrups.Add("Caramel");
            Syrups.Add("Hazelnut");
            User.Add("Gość");
            LoadUsersFromDatabase();
        }

        private void LoadUsersFromDatabase()
        {
            using (var db = new CoffeeDbContext())
            {
                var users = db.Users.ToList();
                foreach (var user in users)
                {
                    User.Add(user.UserName); 
                }
            }
        }

        private void UpdatePriceAndImage()
        {
            TotalPrice = 0.0m;


            if (SelectedCoffee == "Espresso")
            {
                CoffeeImage = "pack://application:,,,/Images/Kafka3.jpg";
                TotalPrice += 9.0m;
            }
            else if (SelectedCoffee == "Latte")
            {
                CoffeeImage = "pack://application:,,,/Images/Kafka2.jpg";
                TotalPrice += 8.0m;
            }
            else if (SelectedCoffee == "Cappuccino")
            {
                CoffeeImage = "pack://application:,,,/Images/Kafka1.jpg";
                TotalPrice += 8.5m;
            }
            EarnedPoints = (int)(TotalPrice / 5);

            if (!string.IsNullOrEmpty(SelectedMilk) && (SelectedMilk=="Oat")) TotalPrice += 1.0m;
            if (!string.IsNullOrEmpty(SelectedMilk) && (SelectedMilk == "Almond")) TotalPrice += 1.05m;
            if (!string.IsNullOrEmpty(SelectedMilk) && (SelectedMilk == "Regular")) TotalPrice += 1.25m;

        
            if (!string.IsNullOrEmpty(SelectedSyrup) && (SelectedSyrup=="Vanilla")) TotalPrice += 0.25m;
            if (!string.IsNullOrEmpty(SelectedSyrup) && (SelectedSyrup == "Caramel")) TotalPrice += 0.3m;
            if (!string.IsNullOrEmpty(SelectedSyrup) && (SelectedSyrup == "Hazelnut")) TotalPrice += 0.45m;

        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CoffeeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=coffee.db");
        }
    }



    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; } 
        public string Role { get; set; }
        public int LoyaltyPoints { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public string Coffee { get; set; }
        public string Milk { get; set; }
        public string Syrup { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
    }


}
