using System.Threading.Tasks;

namespace PokemonAPI.Service
{
    public interface IPokemonService
    {
        Task<string> FindDescriptionByNameAsync(string pokemonName);
    }
}