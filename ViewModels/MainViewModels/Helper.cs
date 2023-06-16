using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelBase;
using DataModels;
using ViewModelBase.Commands.ErrorHandlers;
using DataModels.Entities;

namespace MainViewModels
{
    public static class Helper
    {
        public static DataManager DataModel = DataManager.Get(DataProvidersList.SqlServer);
        public static IErrorHandler? ErrorHandler {internal get; set; }
        public static Action<object?>? LoginGames { internal get; set; }
        public static Action<object?>? ReginLogin { internal get; set; }
        public static Action<object?>? UnlogUser { internal get; set; }
        internal static Users? CurrentUser = null;
    }
}
