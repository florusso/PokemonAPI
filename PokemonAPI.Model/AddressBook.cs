using System;
using System.Collections.Generic;

namespace PokemonAPI.Model
{
    public class AddressBook
    {
        public List<PokeAddress> addressbook { get; set; }
    }

    public class PokeAddress
    {
        public string name { get; set; }
        public string url { get; set; }
    }



}
