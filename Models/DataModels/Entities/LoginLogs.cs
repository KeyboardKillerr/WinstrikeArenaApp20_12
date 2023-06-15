using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Entities
{
    [Index(nameof(LoginDateTime), nameof(UserId))]
    public class LoginLogs : EntityBase
    {
        public DateTime LoginDateTime { get; set; }
        [ForeignKey("FK_UserId")]
        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;
    }
}
