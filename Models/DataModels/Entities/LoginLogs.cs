using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Entities
{
    public class LoginLogs 
    {
        public DateTime LoginDateTime { get; set; }
        [Key]
        [ForeignKey("FK_UserId")]
        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;
        [ForeignKey("FK_ComputerId")]
        public Guid ComputerId { get; set; }
        public Computers Computer { get; set; } = null!;
    }
}
