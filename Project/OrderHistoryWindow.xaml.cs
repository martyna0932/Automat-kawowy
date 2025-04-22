using System.Windows;
using CoffeeOrderApp.Repositories;
using CoffeeOrderApp.Models;

namespace Project
{
    public partial class OrderHistoryWindow : Window
    {
        private readonly IOrderRepository _orderRepository;

        public OrderHistoryWindow()
        {
            InitializeComponent();
            _orderRepository = new OrderRepository(new CoffeeDbContext());
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            var orders = _orderRepository.GetAllOrders();
            OrdersDataGrid.ItemsSource = orders;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SwitchUser switchUser = new SwitchUser();
            switchUser.Show();
            this.Close();
        }
    }
}
