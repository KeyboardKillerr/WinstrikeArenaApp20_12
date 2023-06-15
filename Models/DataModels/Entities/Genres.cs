using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Entities
{
    [Index(nameof(Name))]
    public class Genres : EntityBase
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public IList<Games> Games { get; set; } = new List<Games>();
    }
}
