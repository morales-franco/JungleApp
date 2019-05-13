using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models.PatternMatching
{
    public class Pig:Animal
    {
        public Pig(string name, eClassificationAnimal classification, string country) : base(name, classification, country)
        {
        }

        public override eFavoriteFood GetFavouriteFood()
        {
            return eFavoriteFood.Plants;
        }

        public override void SayHello()
        {
            Console.WriteLine($"OINKK I'm { Name } - the { GetClassificationAnimal() }");
        }
    }
}
