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
    /// Логика взаимодействия для GamesAndGenresPage.xaml
    /// </summary>
    public partial class GamesAndGenresPage : Page
    {
        private DataViewModel model;
        public GamesAndGenresPage()
        {
            InitializeComponent();
            DataContext = App.viewModel;
            if (DataContext is DataViewModel viewmodel) model = viewmodel;
        }

        private void GoToAdmin(object sender, RoutedEventArgs e) => SetHelper.NaviToAdmin(null);
    }
}
