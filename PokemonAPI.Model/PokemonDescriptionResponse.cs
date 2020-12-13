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

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
