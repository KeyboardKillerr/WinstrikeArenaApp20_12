using MainViewModels;
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
    /// Логика взаимодействия для GamesPage.xaml
    /// </summary>
    public partial class GamesPage : Page
    {
        private DataViewModel model;
        public GamesPage()
        {
            InitializeComponent();
            DataContext = App.viewModel;
            if (DataContext is DataViewModel viewmodel) model = viewmodel;
        }

        private void Button_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == e.OldValue) return;
            AdminBtn.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Hidden;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AdminBtn.Visibility = model.CurrentUser.Administartor ? Visibility.Visible : Visibility.Hidden;
        }

        private void GoToLogin(object sender, RoutedEventArgs e) => SetHelper.NaviToLogin(null);
        private void GoToAdmin(object sender, RoutedEventArgs e) => SetHelper.NaviToAdmin(null);
        private void GoToFavorites(object sender, RoutedEventArgs e) => SetHelper.NaviToFavorites(null);
        private void GoToApps(object sender, RoutedEventArgs e) => SetHelper.NaviToApps(null);
        private void GoToProfile(object sender, RoutedEventArgs e) => SetHelper.NaviToProfile(null);
    }
}
