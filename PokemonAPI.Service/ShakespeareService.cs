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
        public async Task<string> TranslateAsync(string text)
        {
            var shakespearResource = $"https://api.funtranslations.com/translate/shakespeare.json?text={text}";

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
                            //TODO:Handle Too many call error
                            //response.ReasonPhrase
                            // response.StatusCode
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
                // _logger.LogError(ex, "ShakespeareService.Tranlaste");
            }


            return translated;
        }
    }
}
