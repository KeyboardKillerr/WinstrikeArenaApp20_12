using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Entities
{
    public class Apps : EntityBase
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int SizeMb { get; set; }
        public IList<Computers> Installed { get; set; } = new List<Computers>();
    }
}
