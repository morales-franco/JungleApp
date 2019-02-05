using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public class Pet
    {
        public string Name { get; private set; }
        public string Color { get; private set; }

        //TODO: public access
        /*
         * accesible within the class as well as outside the class.
         * outside the project too
         */
        public bool IsVaccinated { get; set; }

        //TODO: private access
        /*
         * only accesible within the class, can not be accessed from outside the class
         */
        private string EyeColor { get; set; }

        //TODO: protected access
        /*
         * The type or member can be accessed only by code in the same class or struct, or in a class that is derived from that class (child class).
         */
        protected decimal Weight { get; set; }

        //TODO: internal access
        /*
         * The type or member can be accessed by any code in the same assembly, but not from another assembly.
         * In C# classes by default are internal., which means no external assembly could access default
classes. They could only be accessible to other assemblies if classes are marked with public access specifiers.
         */
        internal int Height { get; set; }


        /*
         * protected - accessible for inherited classes, otherwise private.
         * internal - public only for classes inside the assembly, otherwise private.
         * protected internal - means protected or internal - methods become accessible for inherited classes and for any classes inside the assembly.
         */

        protected internal int Lenght{ get ;set;}


        public Pet(string name, string color)
        {
            Name = name;
            Color = color;
            IsVaccinated = true;
            EyeColor = "Brown";
        }

    }
}
