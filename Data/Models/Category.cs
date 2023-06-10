using System.ComponentModel.DataAnnotations;

namespace WebProjectAPI.Data.Models
{
    public class Category
    {
        /* id: unique identifier for the category
            name: name of the category
        movies: a list of movie IDs associated with the category
         */
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
