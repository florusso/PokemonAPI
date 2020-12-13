using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonAPI.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAPI.Service.Tests
{
    [TestClass()]
    public class IntegrationTests
    {
        [TestMethod()]
        public void TranslateAsyncTest()
        {


            var pokemonService = new PokemonService();
            var pokeName = "bulbasaur";
            var description = pokemonService.FindDescriptionByNameAsync(pokeName).GetAwaiter().GetResult();


            
            var svc = new ShakespeareService();
            var translated=  svc.TranslateAsync(description).GetAwaiter().GetResult();

            Assert.AreNotEqual(description,translated);
        }
    }
}