﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hotel;
using HotelApp;

namespace HotelApp
{
    public partial class TourPage : Page
    {
        public TourPage()
        {
            InitializeComponent();
            DGridHotel.ItemsSource = HotelEntities.GetContext().Туры.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedHotel = DGridHotel.SelectedItem as Отель;
            NavigationService.Navigate(new AddEditHotelsPage(null));
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedHotel = (sender as Button).DataContext as Отель;
            NavigationService.Navigate(new AddEditHotelsPage(selectedHotel));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedHotel = DGridHotel.SelectedItem as Отель;
            HotelEntities.GetContext().Отель.Remove(selectedHotel);
            HotelEntities.GetContext().SaveChanges();
        }
    }
}
