using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonAPI.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonAPI.Service.Tests
{
    [TestClass()]
    public class ShakespeareServiceTests
    {
        [TestMethod()]
        public void TranslateAsyncTest()
        {
            var text = "You gave Mr. Tim a hearty meal, but unfortunately what he ate made him die.";
            var svc = new ShakespeareService();
            var translated=  svc.TranslateAsync(text).GetAwaiter().GetResult();

            Assert.IsNotNull(translated);
        }
    }
}