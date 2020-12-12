using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonAPI.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAPI.Service.Tests
{
    [TestClass()]
    public class PokemonServiceTests
    {
        [TestMethod()]
        public void PokemonServiceTest()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void FindDescriptionByNameAsyncTest()
        {
            var pokemonService = new PokemonService();
            var pokeName = "francesco";
            var description = pokemonService.FindDescriptionByNameAsync(pokeName).GetAwaiter().GetResult();
            Assert.IsFalse(String.IsNullOrEmpty(description));
        }
    }
}