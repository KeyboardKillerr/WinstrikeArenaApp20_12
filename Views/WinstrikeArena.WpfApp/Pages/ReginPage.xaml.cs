using CaptchaGen.SkiaSharp;
using MainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class ReginPage : Page
    {
        private DataViewModel model;
        public ReginPage()
        {
            InitializeComponent();
            DataContext = App.viewModel;
            if (DataContext is DataViewModel viewmodel) model = viewmodel;
            DisplayCaptcha();
            model.LoginReginVM.Notify += DisplayCaptcha;
        }

        private void DisplayCaptcha()
        {
            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = new CaptchaGenerator().GenerateImageAsStream(model.LoginReginVM.Captcha);
            imageSource.EndInit();
            CaptchaImage.Source = imageSource;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            SetHelper.NaviToLogin(null);
        }

        private void PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            model.LoginReginVM.Password = PassBox.Password;
        }
    }
}
