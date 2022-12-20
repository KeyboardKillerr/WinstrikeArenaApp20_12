using DataModels.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataModels.DataProviders.Ef.Core.Repositories;
using System.IO;

namespace DataModels
{
    public class DataManager
    {
        public IAppsRep App { get; }
        public IComputersRep Computer { get; }
        public IGamesRep Game { get; }
        public IGenresRep Genre { get; }
        public ILoginLogsRep LoginLog { get; }
        public IRatesRep Rate { get; }
        public IUsersRep User { get; }
        public IZonesRep Zone { get; }

        //public DbContext? Context { get; }

        private DataManager(IAppsRep app, IComputersRep computer, IGamesRep game, IGenresRep genre, ILoginLogsRep loginLog, IRatesRep rate, IUsersRep user, IZonesRep zone)
        {
            App = app;
            Computer = computer;
            Game = game;
            Genre = genre;
            LoginLog = loginLog;
            Rate = rate;
            User = user;
            Zone = zone;
        }

        public static DataManager Get(DataProvidersList dataProviders)
        {
            switch (dataProviders)
            {
                case DataProvidersList.Json:
                case DataProvidersList.Txt:
                case DataProvidersList.Oracle:
                case DataProvidersList.SqLite:
                    var sqlite = new DataProviders.Ef.Contexts.SqlServerDbContext();
                    if (!Directory.Exists(@"C:\Data")) Directory.CreateDirectory(@"C:\Data");
                    if (!sqlite.Database.EnsureCreated()) throw new Exception();
                    return new DataManager
                    (
                        new EfApps(sqlite),
                        new EfComputers(sqlite),
                        new EfGames(sqlite),
                        new EfGenres(sqlite),
                        new EfLoginLogs(sqlite),
                        new EfRates(sqlite),
                        new EfUsers(sqlite),
                        new EfZones(sqlite)
                    );
                case DataProvidersList.MySql:
                    throw new NotSupportedException("Поставщики данных находятся в стадии разработки");
                case DataProvidersList.SqlServer:
                    var context = new DataProviders.Ef.Contexts.SqlServerDbContext();
                    context.Database.EnsureCreated();
                    return new DataManager
                    (
                        new EfApps(context),
                        new EfComputers(context),
                        new EfGames(context),
                        new EfGenres(context),
                        new EfLoginLogs(context),
                        new EfRates(context),
                        new EfUsers(context),
                        new EfZones(context)
                    );
                default:
                    throw new NotSupportedException("Поставщики данных неизвестен");
            }
        }
    }
}
