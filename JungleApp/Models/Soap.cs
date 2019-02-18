using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public class Soap : IFood, IDrink
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Soap()
        {

        }

        public Soap(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
