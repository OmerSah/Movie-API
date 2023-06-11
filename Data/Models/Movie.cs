namespace WebProjectAPI.Data.Models
{
    public class Movie
    {
        /* id: unique identifier for the movie
title: title of the movie
description: brief description of the movie
producer: ID of the producer associated with the movie
actors: a list of actor IDs associated with the movie
categories: a list of category IDs associated with the movie */
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Category> Categories { get; set; }
    }
}
