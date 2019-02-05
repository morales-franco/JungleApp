using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public class Cat : Pet
    {
        //TODO: use constructor of super class
        public Cat(string name, string color) : base(name, color)
        {
            Height = 10;
            Weight = 20;
            Lenght = 30;
            IsVaccinated = true;
            //EyeColor = ""; Private
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
    }
}
