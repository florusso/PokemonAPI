using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var pockLogger = new Mock<ILogger<PokemonService>>();

            var shakLogger = new Mock<ILogger<ShakespeareService>>();

            var pokemonService = new PokemonService(pockLogger.Object);
            var pokeName = "bulbasaur";
            var description = pokemonService.FindDescriptionByNameAsync(pokeName).GetAwaiter().GetResult();


            
            var svc = new ShakespeareService(shakLogger.Object);
            var translated=  svc.TranslateAsync(description).GetAwaiter().GetResult();

            Assert.AreNotEqual(description,translated);
        }
    }
}