using System.Collections.Generic;

namespace Pokedex.Modelos_Api
{
    public class Pokemon_Api
    {
            public int Order { get; set; }

            public string Name { get; set; }

            public List<Types_Api> Types { get; set; }

            public int Id { get; set; }
        }
}
