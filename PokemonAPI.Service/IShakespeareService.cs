using System.Threading.Tasks;

namespace PokemonAPI.Service
{
    public interface IShakespeareService
    {
        Task<string> TranslateAsync(string text);
    }
}