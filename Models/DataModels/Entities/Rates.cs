using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Entities
{
    public class Rates : EntityBase
    {
        public string Name { get; set; } = null!;
        public int Hours { get; set; }
        public int? StartTime { get; set; } 
        public double Price { get; set; }
        public IList<Users> Users { get; set; } = new List<Users>();
        [ForeignKey("FK_ZoneId")]
        public Guid ZoneId { get; set; }
        public ComputerZones Zone { get; set; } = null!;
    }
}
