using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonAPI.Model;

namespace PokemonAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/pokemon/{pokemon_name}")]
        public PokemonDescriptionResponse GetPokemonDescription(string pokemon_name)
        {
            return new PokemonDescriptionResponse { Name = pokemon_name, Description = "Super" };
        }
    }
}
