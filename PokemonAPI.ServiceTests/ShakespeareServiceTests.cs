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
    public class ShakespeareServiceTests
    {
        [TestMethod()]
        public void TranslateAsyncTest()
        {
            var mockLogger = new Mock<ILogger<ShakespeareService>>();
            var text = "You gave Mr. Tim a hearty meal, but unfortunately what he ate made him die.";
            var svc = new ShakespeareService(mockLogger.Object);
            var translated=  svc.TranslateAsync(text).GetAwaiter().GetResult();

            Assert.IsNotNull(translated);
        }
    }
}