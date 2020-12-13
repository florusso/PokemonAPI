using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PokeApiNet;
using PokemonAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Service
{

    public class PokemonService : IPokemonService
    {
        private HashSet<string> _pokemonIndex;
        private readonly ILogger<PokemonService> _logger;
        private readonly IOptions<Pokesettings> _settings;
        public PokemonService(ILogger<PokemonService> logger, IOptions<Pokesettings> settings)
        {
            _logger = logger;
            _settings = settings;
            _pokemonIndex = LoadPokemonIndex(_settings.Value.AddressBookPath);
           

        }

        private HashSet<string> LoadPokemonIndex(string path)
        {
            var ret = new HashSet<string>();
            var addressBook = new AddressBook();
            addressBook = JsonConvert.DeserializeObject<AddressBook>(File.ReadAllText(path));
            ret = new HashSet<string>(addressBook.addressbook.Select(a => a.name).ToArray());
            return ret;
        }
        /// <summary>
        ///Given a Pokemon name,returns the description 
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns>
        /// Returns the description of the Pokemon if exists;<br/>
        /// Empty string if the pokemon does not exist;<br/>
        /// Null if something goes wrong;
        /// </returns>
        public async Task<string> FindDescriptionByNameAsync(string pokemonName)
        {

            PokeApiClient pokeClient = new PokeApiClient();
            var descriprtion = string.Empty;

            try
            {
                /*to avoid error 404 Pokemon not found ,i have preloaded all the pokemon'names
                 * and i chek in my HashSet before.
                 */
                if (_pokemonIndex.Contains(pokemonName))

                {
                    Pokemon pokemon = await pokeClient.GetResourceAsync<Pokemon>(pokemonName);
                    Ability ability = await pokeClient.GetResourceAsync<Ability>(pokemon.Abilities[0].Ability.Name);
                    descriprtion = ability.EffectEntries.FirstOrDefault(e => e.Language.Name == "en").Effect;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }



            return descriprtion;

        }
    }
}
