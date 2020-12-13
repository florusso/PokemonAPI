using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PokemonAPI.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Service
{
    public class ShakespeareService : IShakespeareService
    {
        private readonly ILogger<ShakespeareService> _logger;
        private readonly IOptions<Pokesettings> _settings;
        public ShakespeareService(ILogger<ShakespeareService> logger, IOptions<Pokesettings> settings)
        {
            _logger = logger;
            _settings = settings;
        }
        public async Task<string> TranslateAsync(string text)
        {
            var shakespearResource = $"{_settings.Value.ShekspeareApiUrl}?text={text}";

            var translated = string.Empty;
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(shakespearResource))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpContent content = response.Content)
                            {
                                string myContent = await content.ReadAsStringAsync();

                                var ret = JsonConvert.DeserializeObject<ShakespeareApiResponse>(myContent);

                                if (ret.success.total > 0)
                                {
                                    translated = ret.contents.translated;
                                }

                            }
                        }
                        else
                        {
                            _logger.LogWarning($"StatusCode: {response.StatusCode} ReasonPhrase:{response.ReasonPhrase}");

                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ShakespeareService.Tranlaste");
                return null;
            }


            return translated;
        }
    }
}
