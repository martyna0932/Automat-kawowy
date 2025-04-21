using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic; // Dodane, ponieważ będziemy używać List<>
using Project;
using CoffeeOrderApp;
using CoffeeOrderApp.Repositories;
using CoffeeOrderApp.Models;

namespace Project
{
    public partial class OrderHistoryWindow : Window
    {
        public OrderHistoryWindow()
        {
            InitializeComponent();
            LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            using (var dbContext = new CoffeeDbContext())
            {
                // Pobierz wszystkie zamówienia z bazy danych
                var orders = dbContext.Orders.ToList();

                // Przypisz dane do DataGrid
                OrdersDataGrid.ItemsSource = orders;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
    }
}
