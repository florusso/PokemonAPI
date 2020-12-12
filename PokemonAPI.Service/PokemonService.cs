using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Service
{
    
    public class PokemonService
    {
      //  private Dictionary<string, int> _PokemonIndex;
        public PokemonService()
        {
           // _PokemonIndex = LoadPokemonIndex();
        }

        //private Dictionary<string, int> LoadPokemonIndex()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<string> FindDescriptionByNameAsync(string pokemonName)
        {
            // instantiate client
            PokeApiClient pokeClient = new PokeApiClient();
            var descriprtion = string.Empty;
            // get a resource by name
            try
            {
                Pokemon pokemon = await pokeClient.GetResourceAsync<Pokemon>(pokemonName);
                Ability ability = await pokeClient.GetResourceAsync<Ability>(pokemon.Abilities[0].Ability.Name);
                descriprtion = ability.EffectEntries.FirstOrDefault(e => e.Language.Name == "en").Effect;
            }
            catch (System.Net.Http.HttpRequestException ex)
            {

                return descriprtion;
            }
           
           

            return descriprtion;

        }
    }
}
