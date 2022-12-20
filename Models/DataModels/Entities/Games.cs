﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Entities
{
    public class Games : EntityBase
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int SizeMb { get; set; }
        public IList<Users> Users { get; set; } = new List<Users>();
        public IList<Computers> Installed { get; set; } = new List<Computers>();
        public IList<Genres> GamesGenres { get; set; } = new List<Genres>();
    }
}
