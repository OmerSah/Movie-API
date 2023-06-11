using System.Text.Json.Serialization;
using WebProjectAPI.Data.Models.Base;

namespace WebProjectAPI.Data.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [JsonIgnore]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Category> Categories { get; set; }
    }
}
