using System;
using System.Linq;
using System.Windows;
using CoffeeOrderApp.Repositories;
using CoffeeOrderApp.Models;
using Microsoft.EntityFrameworkCore;
using Project;
using System.ComponentModel;


namespace CoffeeOrderApp
{
    public partial class MainWindow : Window
    {
        public int LoggedUserId { get; set; }
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public MainWindow()
        {
            InitializeComponent();
            

            _orderRepository = new OrderRepository(new CoffeeDbContext());
            _userRepository = new UserRepository(new CoffeeDbContext());

            DataContext = new CoffeeViewModel(_userRepository);
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
                    UserId = LoggedUserId
                };

                int earnedPoints = viewModel.EarnedPoints;

               
                _orderRepository.AddOrder(order);

              
                var user = _userRepository.GetUserById(LoggedUserId);
                if (user != null)
                {
                    user.LoyaltyPoints += earnedPoints;
                    _userRepository.UpdateUser(user); 
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
        private readonly IUserRepository _userRepository;
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

        public CoffeeViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            LoadUserChoices();  
        }
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

            LoadUsersFromRepository();
        }

  
        private void LoadUsersFromRepository()
        {
            var users = _userRepository.GetAllUsers(); 
            foreach (var user in users)
            {
                User.Add(user.UserName); 
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

            if (!string.IsNullOrEmpty(SelectedMilk) && (SelectedMilk == "Oat")) TotalPrice += 1.0m;
            if (!string.IsNullOrEmpty(SelectedMilk) && (SelectedMilk == "Almond")) TotalPrice += 1.05m;
            if (!string.IsNullOrEmpty(SelectedMilk) && (SelectedMilk == "Regular")) TotalPrice += 1.25m;

            if (!string.IsNullOrEmpty(SelectedSyrup) && (SelectedSyrup == "Vanilla")) TotalPrice += 0.25m;
            if (!string.IsNullOrEmpty(SelectedSyrup) && (SelectedSyrup == "Caramel")) TotalPrice += 0.3m;
            if (!string.IsNullOrEmpty(SelectedSyrup) && (SelectedSyrup == "Hazelnut")) TotalPrice += 0.45m;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
