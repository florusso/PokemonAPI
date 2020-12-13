using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonAPI.Model;
using PokemonAPI.Service;

namespace PokemonAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private IPokemonService _pokemonService;
        private IShakespeareService _shakespeareService;

        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonService, IShakespeareService shakespeareService)
        {
            _logger = logger;
            _pokemonService = pokemonService;
            _shakespeareService = shakespeareService;

        }

        [HttpGet]
        [Route("/pokemon/{pokemon_name}")]
        public async Task<ActionResult<PokemonDescriptionResponse>> GetPokemonDescriptionAsync(string pokemon_name)
        {
            var ret = new PokemonDescriptionResponse();
            ret.Name = pokemon_name;
            try
            {
                var desc = await _pokemonService.FindDescriptionByNameAsync(pokemon_name);

                if (desc is null) return InternalError();
               

                if (desc == string.Empty)
                {
                    _logger.LogWarning($"{pokemon_name}: not found");
                    return NotFound();
                }


                ret.Description = await _shakespeareService.TranslateAsync(desc);

                if (string.IsNullOrEmpty(ret.Description)) return InternalError();
              

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                throw;
            }
            return Ok(ret);
        }

        private ObjectResult InternalError()
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went really wrong, we are very sorry!");
        }
    }
}
