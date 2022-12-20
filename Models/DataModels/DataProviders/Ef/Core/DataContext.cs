﻿using DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.DataProviders.Ef.Core
{
    public class DataContext : DbContext
    {
        public DbSet<Apps> Applications { get; set; } = null!;
        public DbSet<Computers> Computers { get; set; } = null!;
        public DbSet<Games> Games { get; set; } = null!;
        public DbSet<Genres> Genres { get; set; } = null!;
        public DbSet<LoginLogs> LoginLogs { get; set; } = null!;
        public DbSet<Rates> Rates { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<ComputerZones> Zones { get; set; } = null!;
        //protected override void OnModelCreating(ModelBuilder mb)
        //{
        //    //mb.Entity<Application>()
        //    //    .HasMany<Computer>(a=>a.Installed)
        //    //    .WithMany(c=>c.Applications)
        //    //    .Map()
        //}
    }
}