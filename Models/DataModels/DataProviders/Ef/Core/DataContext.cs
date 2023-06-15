using DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EFCore.CheckConstraints;

namespace DataModels.DataProviders.Ef.Core
{
    public class DataContext : DbContext
    {
        public DbSet<Computers> Computers { get; set; } = null!;
        public DbSet<Games> Games { get; set; } = null!;
        public DbSet<Genres> Genres { get; set; } = null!;
        public DbSet<LoginLogs> LoginLogs { get; set; } = null!;
        public DbSet<Rates> Rates { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<ComputerZones> Zones { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder mb)
        {
            var user = new Users()
            {
                Id = Guid.NewGuid(),
                NickName = "admin",
                Password = Entities.Users.ToHashString("12345"),
                Role = 3
            };
            mb.Entity<Users>().HasData(user);
        }
    }
}
