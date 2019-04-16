using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleApp.Batch.Entities
{
    class Country
    {
        public string Name { get; private set; }
        public string Continent { get; private set; }

        public Country(string name, string continent)
        {
            Name = name;
            Continent = continent;
        }

    }
}
