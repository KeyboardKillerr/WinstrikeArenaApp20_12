using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using DataModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Tests
{
    [TestClass()]
    public class DataManagerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            var data = DataManager.Get(DataProvidersList.SqlServer);
            //var genre = new Genres()
            //{
            //    Name = "FPS"
            //};
            //var game = new Games()
            //{
            //    Name = "TestGame",
            //    SizeMb = 5
            //};

            //_ = data.Game.UpdateAsync(game).Result;
            //_ = data.Genre.UpdateAsync(genre).Result;

            //var genre = data.Genre.Items.FirstOrDefaultAsync().Result;
            //var game = data.Game.Items.FirstOrDefaultAsync().Result;
            //if (game == null) throw new Exception("Game");
            //if (genre == null) throw new Exception("Genre");
            //game.GamesGenres.Add(genre);
            //_ = data.Game.UpdateAsync(game).Result;

            Assert.IsFalse(false);
        }
    }
}