using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokemonAPI.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            var pokemonService = new PokemonService(mockLogger.Object);
            Assert.IsNotNull(pokemonService);
        }


        [TestMethod()]
        public void FindDescriptionByNameAsyncTest()
        {
            var mockLogger = new Mock<ILogger<PokemonService>>();
            var pokemonService = new PokemonService(mockLogger.Object);
            var pokeName = "bulbasaur";
            var description = pokemonService.FindDescriptionByNameAsync(pokeName).GetAwaiter().GetResult();
            Assert.IsFalse(String.IsNullOrEmpty(description));
        }
    }
}