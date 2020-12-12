using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            var pokemonService = new PokemonService();
            Assert.IsNotNull(pokemonService);
        }


        [TestMethod()]
        public void FindDescriptionByNameAsyncTest()
        {
            var pokemonService = new PokemonService();
            var pokeName = "bulbasaur";
            var description = pokemonService.FindDescriptionByNameAsync(pokeName).GetAwaiter().GetResult();
            Assert.IsFalse(String.IsNullOrEmpty(description));
        }
    }
}