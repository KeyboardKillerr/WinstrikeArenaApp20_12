using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainViewModels;
using System.Windows;
using WinstrikeArena.WpfApp.Pages;
using System.Windows.Controls;
using System.Windows.Media;
using DataModels.Entities;
using DataModels.DataProviders.Ef.Core.Repositories;

namespace WinstrikeArena.WpfApp
{
    internal static class SetHelper
    {
        public static MainWindow MainWin { get; set; }
        private static Page loginPage { get; set; }
        private static Page reginPage { get; set; }
        private static Page mainPage { get; set; }
        private static Page favoritesPage { get; set; }
        private static Page profilePage { get; set; }
        private static Page adminPage { get; set; }
        private static Page logsPage { get; set; }
        private static Page usersPage { get; set; }
        private static Page gamesAndGenresPage { get; set; }
        private static Page moderPage { get; set; }
        private static Page rentsPage { get; set; }
        private static Page usersRentsPage { get; set; }
        private static Page computersPage { get; set; }
        static SetHelper()
        {
            Helper.ErrorHandler = new ErrorHandler();
            Helper.LoginGames = NaviToMain;
            Helper.ReginLogin = NaviToLogin;
            Helper.UnlogUser = NaviToLogin;

            loginPage = new LoginPage();
            reginPage = new ReginPage();
            mainPage = new MainPage();
            favoritesPage = new FavoritesPage();
            profilePage = new ProfilePage();
            adminPage = new AdminPage();
            logsPage = new LogsPage();
            usersPage = new UsersPage();
            gamesAndGenresPage = new GamesAndGenresPage();
            rentsPage = new RentsPage();
            moderPage = new ModerPage();
            usersRentsPage = new UsersRentsPage();
            computersPage = new ComputersPage();

        }
        internal static void NaviToLogin(object obj) => MainWin.MainFrame.Navigate(loginPage);
        internal static void NaviToRegin(object obj) => MainWin.MainFrame.Navigate(reginPage);
        internal static void NaviToMain(object obj) => MainWin.MainFrame.Navigate(mainPage);
        internal static void NaviToAdmin(object obj) => MainWin.MainFrame.Navigate(adminPage);
        internal static void NaviToModer(object obj) => MainWin.MainFrame.Navigate(moderPage);
        internal static void NaviToFavorites(object obj) => MainWin.MainFrame.Navigate(favoritesPage);
        internal static void NaviToProfile(object obj) => MainWin.MainFrame.Navigate(profilePage);
        internal static void NaviToUsers(object obj) => MainWin.MainFrame.Navigate(usersPage);
        internal static void NaviToGamesAndGenres(object obj) => MainWin.MainFrame.Navigate(gamesAndGenresPage);
        internal static void NaviToRents(object obj) => MainWin.MainFrame.Navigate(rentsPage);
        internal static void NaviToLogs(object obj) => MainWin.MainFrame.Navigate(logsPage);
        internal static void NaviToUsersRents(object obj) => MainWin.MainFrame.Navigate(usersRentsPage);
        internal static void NaviToComputers(object obj) => MainWin.MainFrame.Navigate(computersPage);
    }
}
