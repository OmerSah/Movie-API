using WebProjectAPI.Data.Models.Base;

namespace WebProjectAPI.Data.Models
{
    public class Actor: BaseEntity
    {
        /* id: unique identifier for the actor
name: name of the actor
movies: a list of movie IDs associated with the actor */
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
