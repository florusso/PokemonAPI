using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokemonAPI.Model;
using System;

namespace PokemonAPI.Service.Tests
{
    [TestClass()]
    public class PokemonServiceTests
    {
        [TestMethod()]
        public void PokemonServiceTest()
        {
            // Assert.ThrowsException<NotImplementedException>(() =>  new PokemonService());

            //Assert.ThrowsException<DirectoryNotFoundException>(() => new PokemonService());
            var mockLogger = new Mock<ILogger<PokemonService>>();
            var settings = Options.Create(new Pokesettings());
            settings.Value.AddressBookPath = "Data/AddressBook.json";

            var pokemonService = new PokemonService(mockLogger.Object, settings);
            Assert.IsNotNull(pokemonService);
        }


        [TestMethod()]
        public void FindDescriptionByNameAsyncTest()
        {
            var mockLogger = new Mock<ILogger<PokemonService>>();
            var settings = Options.Create(new Pokesettings());
            settings.Value.AddressBookPath = "Data/AddressBook.json";

            var pokemonService = new PokemonService(mockLogger.Object, settings);
            var pokeName = "bulbasaur";
            var description = pokemonService.FindDescriptionByNameAsync(pokeName).GetAwaiter().GetResult();
            Assert.IsFalse(String.IsNullOrEmpty(description));
        }
    }
}