using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokemonAPI.Model;

namespace PokemonAPI.Service.Tests
{
    [TestClass()]
    public class IntegrationTests
    {
       
        [TestMethod()]
        public void TranslateAsyncTest()
        {
            var pockLogger = new Mock<ILogger<PokemonService>>();

            var shakLogger = new Mock<ILogger<ShakespeareService>>();
            var settings = Options.Create(new Pokesettings());
            settings.Value.ShekspeareApiUrl = "https://api.funtranslations.com/translate/shakespeare.json";
            settings.Value.AddressBookPath = "Data/AddressBook.json";


            var pokemonService = new PokemonService(pockLogger.Object, settings);
            var pokeName = "bulbasaur";
            var description = pokemonService.FindDescriptionByNameAsync(pokeName).GetAwaiter().GetResult();


            
            var svc = new ShakespeareService(shakLogger.Object, settings);
            var translated=  svc.TranslateAsync(description).GetAwaiter().GetResult();

            Assert.AreNotEqual(description,translated);
        }
    }
}