namespace WebProjectAPI.Data.DTOs
{
    public class AddMovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ProducerId { get; set; }
        public List<int> ActorIds { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
