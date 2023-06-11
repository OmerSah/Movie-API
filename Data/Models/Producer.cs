using System.Text.Json.Serialization;
using WebProjectAPI.Data.Models.Base;

namespace WebProjectAPI.Data.Models
{
    public class Producer: BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public List<Movie> Movies { get; set; }
    }
}
