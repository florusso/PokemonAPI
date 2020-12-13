using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokemonAPI.Model;

namespace PokemonAPI.Service.Tests
{
    [TestClass()]
    public class ShakespeareServiceTests
    {
        [TestMethod()]
        public void TranslateAsyncTest()
        {
            var mockLogger = new Mock<ILogger<ShakespeareService>>();
            var settings = Options.Create(new Pokesettings());
            settings.Value.ShekspeareApiUrl = "https://api.funtranslations.com/translate/shakespeare.json";
            settings.Value.AddressBookPath = "Data/AddressBook.json";

            var text = "You gave Mr. Tim a hearty meal, but unfortunately what he ate made him die.";
            var svc = new ShakespeareService(mockLogger.Object, settings);
            var translated=  svc.TranslateAsync(text).GetAwaiter().GetResult();

            Assert.IsNotNull(translated);
        }
    }
}