using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models.PatternMatching
{
    public class Cow: Animal
    {
        public Cow(string name, eClassificationAnimal classification, string country) : base(name, classification, country)
        {
        }

        public override eFavoriteFood GetFavouriteFood()
        {
            return eFavoriteFood.Plants;
        }

        public override void SayHello()
        {
            Console.WriteLine($"Muu I'm { Name } - the { GetClassificationAnimal() }");
        }
    }
}
