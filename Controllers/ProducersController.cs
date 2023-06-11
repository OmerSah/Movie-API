using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProjectAPI.Data.Models;
using WebProjectAPI.Services;

namespace WebProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducersController(IProducerService producerService)
        {
            this._producerService = producerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_producerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<Producer> GetById(int id)
        {
            return await _producerService.GetById(id);
        }
    }
}
