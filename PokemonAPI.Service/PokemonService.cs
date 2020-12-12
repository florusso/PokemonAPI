using System;
using System.Collections.Generic;

namespace PokemonAPI.Service
{
    
    public class PokemonService
    {
        private Dictionary<string, int> _PokemonIndex;
        public PokemonService()
        {
            _PokemonIndex = LoadPokemonIndex();
        }

        private Dictionary<string, int> LoadPokemonIndex()
        {
            throw new NotImplementedException();
        }

        public void FindByName(string pokemonName)
        {

        }
    }
}
