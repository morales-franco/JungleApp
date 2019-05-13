using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models.PatternMatching
{
    public class Lion : Animal
    {
        public Lion(string name, eClassificationAnimal classification, string country) : base(name, classification, country)
        {
        }

        public override eFavoriteFood GetFavouriteFood()
        {
            return eFavoriteFood.Meat;
        }

        public override void SayHello()
        {
            Console.WriteLine($"Grr I'm { Name } - the { GetClassificationAnimal() }");
        }
    }
}
