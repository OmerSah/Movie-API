using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProjectAPI.Data.Models;
using WebProjectAPI.Services;

namespace WebProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            this._actorService = actorService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_actorService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<Actor> GetById(int id)
        {
            return await _actorService.GetById(id);
        }

    }
}
