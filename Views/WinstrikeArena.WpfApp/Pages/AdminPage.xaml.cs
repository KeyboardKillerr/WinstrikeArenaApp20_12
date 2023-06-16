﻿using MainViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinstrikeArena.WpfApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private DataViewModel model;
        public AdminPage()
        {
            InitializeComponent();
            DataContext = App.viewModel;
            if (DataContext is DataViewModel viewmodel) model = viewmodel;
        }

        private void GoToMain(object sender, RoutedEventArgs e) => SetHelper.NaviToMain(null);
        private void GoToComputers(object sender, RoutedEventArgs e) => SetHelper.NaviToComputers(null);
        private void GoToLogs(object sender, RoutedEventArgs e) => SetHelper.NaviToLogs(null);
        private void GoToUsers(object sender, RoutedEventArgs e) => SetHelper.NaviToUsers(null);
        private void GoToGamesAndGenres(object sender, RoutedEventArgs e) => SetHelper.NaviToGamesAndGenres(null);
    }
}
