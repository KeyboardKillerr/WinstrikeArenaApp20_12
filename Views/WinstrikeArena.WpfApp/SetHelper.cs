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

namespace WinstrikeArena.WpfApp
{
    internal static class SetHelper
    {
        public static MainWindow MainWin { get; set; }
        public static readonly DataManager DataModel = Helper.DataModel;
        private static Page loginPage { get; set; }
        private static Page reginPage { get; set; }
        private static Page gamesPage { get; set; }
        private static Page favoritesPage { get; set; }
        private static Page profilePage { get; set; }
        private static Page adminPage { get; set; }
        private static Page logsPage { get; set; }
        private static Page usersPage { get; set; }
        private static Page gamesAndGenresPage { get; set; }
        private static Page appsPage { get; set; }
        private static Page appsManagment { get; set; }
        static SetHelper()
        {
            Helper.ErrorHandler = new ErrorHandler();
            Helper.LoginGames = NaviToGames;
            Helper.ReginLogin = NaviToLogin;

            loginPage = new LoginPage();
            reginPage = new ReginPage();
            gamesPage = new GamesPage();
            favoritesPage = new FavoritesPage();
            profilePage = new ProfilePage();
            adminPage = new AdminPage();
            logsPage = new LogsPage();
            usersPage = new UsersPage();
            gamesAndGenresPage = new GamesAndGenresPage();
            appsPage = new AppsPage();
            appsManagment = new AppsManagmentPage();

        }
        internal static void NaviToLogin(object obj) => MainWin.MainFrame.Navigate(loginPage);
        internal static void NaviToRegin(object obj) => MainWin.MainFrame.Navigate(reginPage);
        internal static void NaviToGames(object obj) => MainWin.MainFrame.Navigate(gamesPage);
        internal static void NaviToAdmin(object obj) => MainWin.MainFrame.Navigate(adminPage); 
        internal static void NaviToFavorites(object obj) => MainWin.MainFrame.Navigate(favoritesPage);
        internal static void NaviToProfile(object obj) => MainWin.MainFrame.Navigate(profilePage);
        internal static void NaviToUsers(object obj) => MainWin.MainFrame.Navigate(usersPage);
        internal static void NaviToGamesAndGenres(object obj) => MainWin.MainFrame.Navigate(gamesAndGenresPage);
        internal static void NaviToApps(object obj) => MainWin.MainFrame.Navigate(appsPage);
        internal static void NaviToLogs(object obj) => MainWin.MainFrame.Navigate(logsPage);
        internal static void NaviToAppsManagment(object obj) => MainWin.MainFrame.Navigate(appsManagment);
    }
}
