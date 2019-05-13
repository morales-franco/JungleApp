using JungleApp.Models.PatternMatching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Services
{
    public class PatternMatchingService
    {
        public void TestPatternMatching()
        {
            Animal simba = new Lion("Simba", eClassificationAnimal.Carnivores, "Argentina");

            //Before c# 7
            if (simba.GetType() == typeof(Cow))
            {
                var cow = simba as Cow;
            }

            if (simba is Lion)
            {
                JumpLikeALion(simba as Lion);
            }
            else if (simba is Cow)
            {
                JumpLikeACow(simba as Cow);
            }
            else if (simba is Pig)
            {
                JumpLikeAPig(simba as Pig);
            }

            // NOT COMPILE!
            //switch (simba)
            //{
            //    case simba is Lion:
            //        .
            //        .
            //    default:
            //        break;
            //}

            // NOT COMPILE!
            //switch (simba.GetType())
            //{
            //    case typeof(Cow):
            //        .
            //        .
            //    default:
            //        break;
            //}


            //C# 7 introduced a lightweiht version of pattern matching

            switch (simba)
            {
                case Lion lion:
                    JumpLikeALion(lion);
                    break;
                case Cow cow:
                    JumpLikeACow(cow);
                    break;
                case Pig pig:
                    JumpLikeAPig(pig);
                    break;
                default:
                    break;
            }

            //Applying a filter using When Keyword

            switch (simba)
            {
                case Lion lion when lion.GetFavouriteFood() == eFavoriteFood.Meat:
                    EatMeat(lion);
                    break;
                case Lion lion when lion.GetFavouriteFood() == eFavoriteFood.Everything:
                    CallToVeterinarian(lion);
                    break;
                case Lion strangeLion when strangeLion.GetFavouriteFood() == eFavoriteFood.Plants:
                    CallToVeterinarian(strangeLion);
                    break;
                case Cow cow when cow.GetFavouriteFood() == eFavoriteFood.Plants:
                    EatPlants(cow);
                    break;
                default:
                    break;
            }

            //Before set C# 8 as Languague Version
            //The Evolution of Pattern Matching in C# 8.0

            var whatAnimal = simba switch
            {
                Lion _ => "It's a Lion!",
                Cow cow => $"It's a cow: { cow.Name }",
                _ => "It is neither a Lion nor a Cow :("
            };

            Console.WriteLine(whatAnimal);

            var whatAnimalOld = string.Empty;

            if (simba is Lion)
                whatAnimalOld = "It's a Lion!";
            else if (simba is Cow)
                whatAnimalOld = $"It's a cow: { (simba as Cow).Name }";
            else
                whatAnimalOld = "It is neither a Lion nor a Cow :(";

            Console.WriteLine(whatAnimalOld);

            //Property patterns
            var description = GetAnimalDescription(simba);



            //Positional Pattern - Using Deconstruct method

            var result = simba switch
            {
                Lion("Rocky", eClassificationAnimal.Carnivores, "Argentina") => "Simba is from Argentina and eats meats!",
                Lion("Pumba", eClassificationAnimal.Herbivores, _) pumba => $"Pumba is from { pumba.Country } and eats plants!",
                _ => "Object is a unknown Animal"
            };

            Console.WriteLine(result);

            //Using pattern matching in a property
            Console.WriteLine(simba.WhatAnimal);

            Animal piggy = new Pig("piggy", eClassificationAnimal.Omnivores, "New Zealand");
            Console.WriteLine(piggy.WhatAnimal);

            if (piggy.HideFromOtherAnimals)
                Console.WriteLine($"{ piggy.Name } is hiding...");

         
        }

        private string GetAnimalDescription(Animal animal) => animal switch
        {
            Lion { Country: "Argentina", Name: "Simba" } simba   => $"I am { simba.Name} from { simba.Country }",
            Cow { Country: "New Zealand", Name: "Betty" } betty  => $"I am { betty.Name} from { betty.Country }",
            { Name: "Simba" }                                    => "General - Simba!",
            _                                                    => "Description not found"
        };

        private void EatPlants(Cow cow)
        {
            Console.WriteLine($"Eat plants like a cow, {cow.Name}!");
        }

        private void CallToVeterinarian(Lion lion)
        {
            Console.WriteLine($"Calling to veterinarion to schedule a appointment to: {lion.Name}!");
        }

        private void EatMeat(Lion lion)
        {
            Console.WriteLine($"Eat meat like a lion, {lion.Name}!");
        }

        private void JumpLikeAPig(Pig pig)
        {
            Console.WriteLine($"Jump like a pig, {pig.Name}!");
        }

        private void JumpLikeACow(Cow cow)
        {
            Console.WriteLine($"Jump like a cow, {cow.Name}!");
        }

        private void JumpLikeALion(Lion lion)
        {
            Console.WriteLine($"Jump like a lion, {lion.Name}!");
        }
    }
}
