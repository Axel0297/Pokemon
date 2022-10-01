using System.Collections.Generic;

namespace Pokedex
{
    public class Pokemon
    {
        public int Order { get; set; }

        public string Name { get; set; }

        public List<string> Types { get; set; } = new List<string> ();

        public List<string> Evolutions { get; set; } = new List<string>();

        public List<string> PreEvolutions { get; set; } = new List<string>();

    }
}
   