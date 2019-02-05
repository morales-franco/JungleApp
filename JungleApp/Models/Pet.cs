using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public abstract class Pet
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

        protected internal int Lenght { get; set; }


        public Pet(string name, string color)
        {
            Name = name;
            Color = color;
            IsVaccinated = true;
            EyeColor = "Brown";
        }



        public void SayHello()
        {
            Debug.WriteLine($"{ Name } says: hi, mate !");
        }

        //TODO: Abstract method
        //Abstract classes cannot be instantiated. It is used as base class, where it provides common members to all
        //its derived classes.It is either overridden partially or not at all. It is also used to declare abstract methods
        //(method without definition) that when it inherits, it must be overridden by its derived classes.

        //Not possible, si the method is abstract doesn't have a body!
        //public abstract void SayHello()
        //{
        //    Debug.WriteLine($"{ Name } says: hi, miauu !");
        //}

        //A Abstract method just have a firm! --> public abstract void Eat();
        //Subclass must override abstract methods!
        public abstract void Eat();

        //TODO: Dynamic Polymorphism: virtual & abstract
        /*
         * dynamic polymorphism means changing behavior of an object at runtime by overriding the definition of a method. 
         * It is also known as late binding.
         */

        //TODO:Virtual method has a definition of its method; its derived class can inherit or override its definition
        //Override is NOT Required
        public virtual void Move()
        {
            Debug.WriteLine("I'm moving slowly..");
        }

    }
}
