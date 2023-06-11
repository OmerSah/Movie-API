using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Text.Json.Serialization;
using WebProjectAPI.Data.Models.Base;

namespace WebProjectAPI.Data.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class User: BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; } = string.Empty;
        [JsonIgnore]
        public DateTime TokenCreated { get; set; }
        [JsonIgnore]
        public DateTime TokenExpires { get; set; }
    }
}
