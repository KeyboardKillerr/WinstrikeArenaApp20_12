using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Entities
{
    public class Users : EntityBase
    {
        public string NickName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Birhtday { get; set; }
        public string? FullName { get; set; }
        public string? Enail { get; set; }
        public int PhoneNumber { get; set; }
        public bool Administartor { get; set; }
        public IList<Games> FavoriteGames { get; set; } = new List<Games>();
        public IList<Rates> Rates { get; set; } = new List<Rates>();
    }
}
