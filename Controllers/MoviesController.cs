using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProjectAPI.Data.DTOs;
using WebProjectAPI.Data.Models;
using WebProjectAPI.Services;

namespace WebProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IActorService _actorService;
        private readonly IProducerService _producerService;

        public MoviesController(IMovieService movieService, ICategoryService categoryService, IActorService actorService, IProducerService producerService)
        {
            this._movieService = movieService;
            this._categoryService = categoryService;
            this._actorService = actorService;
            this._producerService = producerService;
        }

        [HttpGet]
        public async Task<List<Movie>> GetAsync()
        {
            List<Movie> movies = _movieService.GetAll().ToList();

            for (int i = 0; i < movies.Count; i++)
            {
                movies[i].Categories = await _categoryService.GetAllByMovieId(movies[i].Id);
                movies[i].Actors = await _actorService.GetAllByMovieId(movies[i].Id);
                movies[i].Producer = await _producerService.GetById(movies[i].ProducerId);
            }

            return movies;
        }

        [HttpGet("{id}")]
        public async Task<Movie> GetById(int id)
        {
            return await _movieService.GetById(id);
        }


        [HttpPost]
        public async Task<Movie> AddMovie(AddMovieDTO movieDTO)
        {
            List<Category> categories = new List<Category>();
            List<Actor> actors = new List<Actor>();

            Movie movie = new Movie
            {
                Title = movieDTO.Title,
                Description = movieDTO.Description,
                ImageUrl = movieDTO.ImageUrl,
                ProducerId = movieDTO.ProducerId,
            };

            movie =  await _movieService.Create(movie);

            categories = await _categoryService.GetByIds(movieDTO.CategoryIds);
            actors = await _actorService.GetByIds(movieDTO.CategoryIds);

            movie.Categories = categories;
            movie.Actors = actors;
            movie.Producer = await _producerService.GetById(movieDTO.ProducerId);


            return await _movieService.Update(movie.Id, movie);
        }

        [HttpPut("{id}")]
        public async Task<Movie> UpdateMovie(int id, AddMovieDTO movieDTO)
        {

            Movie movie = await _movieService.GetById(id);

            List<Category> categoriesToDelete = await _categoryService.GetAllByMovieId(id);
            List<Category> categoriesToAdd = await _categoryService.GetByIds(movieDTO.CategoryIds);

            if (categoriesToDelete != null)
            {
                foreach (Category category in categoriesToDelete)
                {
                    await _categoryService.deleteRelation(category.Id, movie.Id);
                }
            }
            if (categoriesToAdd != null)
            {
                foreach (Category category in categoriesToAdd)
                {
                    await _categoryService.addRelation(category.Id, movie.Id);
                }
            }

            List<Actor> actorsToDelete = await _actorService.GetAllByMovieId(id);
            List<Actor> actorsToAdd = await _actorService.GetByIds(movieDTO.ActorIds);

            if (actorsToDelete != null)
            {
                foreach (Actor actor in actorsToDelete)
                {
                    await _actorService.deleteRelation(actor.Id, movie.Id);
                }
            }
            if (actorsToAdd != null)
            {
                foreach (Actor actor in actorsToAdd)
                {
                    await _actorService.addRelation(actor.Id, movie.Id);
                }
            }

            movie.Title = movieDTO.Title;
            movie.Description = movieDTO.Description;
            movie.ImageUrl = movieDTO.ImageUrl;
            movie.ProducerId = movieDTO.ProducerId;

            movie = await _movieService.Update(movie.Id, movie);

            movie.Producer = await _producerService.GetById(movie.ProducerId);
            movie.Categories = categoriesToAdd;    
            movie.Actors = actorsToAdd;

            return movie;
        }

        [HttpDelete("{id}")]
        public async Task DeleteMovie(int id)
        {
            Movie movie = await _movieService.GetById(id);

            List<Category> categories = await _categoryService.GetAllByMovieId(movie.Id);
            List<Actor> actors = await _actorService.GetAllByMovieId(movie.Id);

            if (categories != null)
            {
                foreach (Category category in categories)
                {
                    await _categoryService.deleteRelation(category.Id, movie.Id);
                }
            }
            if (actors != null)
            {
                foreach (Actor actor in actors)
                {
                    await _actorService.deleteRelation(actor.Id, movie.Id);
                }
            }

            await _movieService.Delete(movie.Id);
        }
    }
}
