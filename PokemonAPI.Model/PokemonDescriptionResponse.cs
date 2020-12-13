using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PokemonAPI.Model
{
   public class PokemonDescriptionResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("descriprion")]
        public string Description { get; set; }
    }
}
