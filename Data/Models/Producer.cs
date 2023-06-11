using WebProjectAPI.Data.Models.Base;

namespace WebProjectAPI.Data.Models
{
    public class Producer: BaseEntity
    {
        /* id: unique identifier for the producer
name: name of the producer
movies: a list of movie IDs associated with the producer */
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
