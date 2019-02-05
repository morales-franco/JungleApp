using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public class Drink: IDrink
    {
        public string Description { get; set; }

        public Drink()
        {

        }

        public Drink(string description)
        {
            Description = description;
        }
    }

    public interface IDrink
    {
        string Description { get; set; }
    }
}
