using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebProjectAPI.Data.Models.Base;

namespace WebProjectAPI.Data.Models
{
    public class Category: BaseEntity
    {
        /* id: unique identifier for the category
            name: name of the category
        movies: a list of movie IDs associated with the category
         */
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Movie> Movies { get; set; }
    }
}
