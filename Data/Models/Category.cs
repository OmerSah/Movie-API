using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebProjectAPI.Data.Models.Base;

namespace WebProjectAPI.Data.Models
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public List<Movie> Movies { get; set; }
    }
}
