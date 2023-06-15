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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private DataViewModel model;
        public MainPage()
        {
            InitializeComponent();
            DataContext = App.viewModel;
            if (DataContext is DataViewModel viewmodel) model = viewmodel;
        }

        private void AdminButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == e.OldValue) return;
            AdminBtn.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Hidden;
        }

        private void ModerButton_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == e.OldValue) return;
            ModerBtn.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Hidden;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //AdminBtn.Visibility = model.CurrentUser.Administartor ? Visibility.Visible : Visibility.Hidden;
            if (model.LoginReginVM.CurrentUser.Role == 2) ModerBtn.Visibility = Visibility.Visible;
            else if (model.LoginReginVM.CurrentUser.Role == 3) AdminBtn.Visibility = Visibility.Visible;
            else
            {
                ModerBtn.Visibility = Visibility.Hidden;
                AdminBtn.Visibility = Visibility.Hidden;
            }
        }

        private void GoToLogin(object sender, RoutedEventArgs e) => SetHelper.NaviToLogin(null);
        private void GoToAdmin(object sender, RoutedEventArgs e) => SetHelper.NaviToAdmin(null);
        private void GoToFavorites(object sender, RoutedEventArgs e) => SetHelper.NaviToFavorites(null);
        private void GoToRents(object sender, RoutedEventArgs e) => SetHelper.NaviToRents(null);
        private void GoToProfile(object sender, RoutedEventArgs e) => SetHelper.NaviToProfile(null);
        private void GoToModer(object sender, RoutedEventArgs e) => SetHelper.NaviToModer(null);
    }
}
