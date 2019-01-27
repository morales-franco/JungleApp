using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public class Dog
    {
        public const string DefaultMood = "Happy"; //const: assignment only in declaration

        public readonly DateTime Birth;
        public readonly string Color = "Gray"; //assignment in declaration

        public string Breed { get;  set; }
        public string Name { get;  set; }

        public string Mood { get; private set; } 
        
        public Dog(DateTime birth, string breed, string name)
        {
            if (string.IsNullOrEmpty(breed) || string.IsNullOrEmpty(name))
                throw new ArgumentNullException();

            Birth = birth; //assignment in constructor
            Breed = breed;
            Name = name;
            Mood = DefaultMood;//assign default value
        }

        //It's not possible! Assigment is posible only in Declaration & Constructor
        //public void ChangeColor(string newColor) {
        //    Color = newColor;
        //}

    }
}
