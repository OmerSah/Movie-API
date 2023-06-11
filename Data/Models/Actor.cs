namespace WebProjectAPI.Data.Models
{
    public class Actor
    {
        /* id: unique identifier for the actor
name: name of the actor
movies: a list of movie IDs associated with the actor */
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
