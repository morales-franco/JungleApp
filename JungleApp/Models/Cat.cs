using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public class Cat : Pet, IGlutton
    {
        //Private array
        private string[] FishEaten = { "Atun", "Dorado", "Salmon" };
        internal int LivesLeft;

        //TODO: Indexers encapsulate the value of an array
        //The you can do: var favoriteFish = myCat[0];
        public string this[int index]
        {
            get
            {
                return FishEaten[index];
            }
            set
            {
                FishEaten[index] = value;
            }
        } 
        

        //TODO: use constructor of super class
        public Cat(string name, string color) : base(name, color)
        {
            Height = 10; //internal access
            Weight = 20; //protected
            Lenght = 30; //protected internal
            IsVaccinated = true; //public
            //EyeColor = ""; Private
            LivesLeft = 7;
        }

        //TODO: explicit operator for conversion
        /*
         * Explicit cast 
         * when we do:
         * string valString = (string)cat; --> explicit cast Cat to string
         */
        public static explicit operator string (Cat cat)
        {
            return $"Name: { cat.Name} - Color: { cat.Color }";
        }

        /*
        * Explicit cast 
        * when we do:
        * int valInt = (int)cat; --> explicit cast Cat to int
        */
        public static explicit operator int(Cat cat)
        {
            return 10;
        }

        //TODO: Implicit cast
        /*
         * when we do:
         * List<string> me = cat;
         */

        public static implicit operator List<string>(Cat cat)
        {
            return new List<string>()
            {
                "I'm",
                "a",
                cat.Name
            };
        }
       

        public void AskForMoreFood()
        {
            Debug.WriteLine("I want more fish!");
        }

        //TODO: Static Polymorphism: Overload methods - by type and lenght
        public void Eat(string food)
        {
            Debug.WriteLine($"I'm eating a  {food}...ñam");
        }

        public void Eat(string food1, string food2)
        {
            Debug.WriteLine($"I'm eating a  {food1} and {food2}...ñam");
        }

        public void Eat(Food food)
        {
            Debug.WriteLine($"I'm eating a  {food.Name}...ñam");
        }



        //TODO: Static Polymorphism: Overload operators (we can only overload class or structs--> Not types)
        //TODO: Overload Unary Operators
        public static Cat operator ++ (Cat cat)
        {
            cat.LivesLeft += 100;
            return cat;
        }

        //TODO: Overload Comparison Operator
        public static bool operator < (Cat cat1, Cat cat2)
        {
            return true;
        }

        public static bool operator >(Cat cat1, Cat cat2)
        {
            return true;
        }


        //TODO: Dynamic Polymorphism: Abstract
        public override void Eat()
        {
            Debug.WriteLine("I'm eating a good fish...ñam");
        }

        //TODO: Dynamic Polymorphism: virtual
        public override void Move()
        {
            Debug.WriteLine("sleep 5 minutes and then: ");
            base.Move();
        }


    }
}
