using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Entities
{
    public class Computers : EntityBase
    {
        public string CPU { get; set; } = null!;
        public string GPU { get; set; } = null!;
        public string RAM { get; set; } = null!;
        public string Motherboard { get; set; } = null!;
        public string HardDrive { get; set; } = null!;
        public int HardDriveVolumeMb { get; set; }
        public IList<Games> InstalledGames { get; set; } = new List<Games>();
        [ForeignKey("FK_ZoneId")]
        public Guid ZoneId { get; set; }
        public ComputerZones Zone { get; set; } = null!;
        public int Number { get; set; }
    }
}
