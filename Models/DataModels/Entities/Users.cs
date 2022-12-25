using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DataModels.Entities
{
    public class Users : EntityBase
    {
        public string NickName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Birhtday { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Administartor { get; set; }
        public IList<Games> FavoriteGames { get; set; } = new List<Games>();
        public IList<Rates> Rates { get; set; } = new List<Rates>();
        public static string ToHashString(string pass)
        {
            if (string.IsNullOrWhiteSpace(pass)) return "";
            using SHA1 hash = SHA1.Create();
            return string
                .Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(pass))
                .Select(x => x.ToString()));
        }
    }
}
