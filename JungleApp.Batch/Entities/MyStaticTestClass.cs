using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleApp.Batch.Entities
{
    public sealed class MyStaticTestClass
    {
        private readonly static string Name = "My Static Test Class!";
        internal readonly static DateTime CurrentDate;

        private readonly string text;

        /*
         * TODO: Static constructors
         * 
         * A static constructor does not take access modifiers or have parameters.
         * A static constructor is called automatically to initialize the class before the first instance is created or any static members are referenced.
         * A static constructor cannot be called directly.
         * The user has no control on when the static constructor is executed in the program.
         * 
         * 
         * When we invoque any static method or variable the static constructor is triggered.
         * MyStaticTestClass.CurrentDate
         * MyStaticTestClass.SayHello();
         
         * When we instantiate the class the static constructor is triggered too.
         * var xx = new MyStaticTestClass();
         * 
         * Another test:
         * var date = MyStaticTestClass.CurrentDate;
         * MyStaticTestClass test = new MyStaticTestClass();
         *  
         * Show in the console:
         * "Init in the static constructor"
         * "Init in the instance constructor"
         * 
         * --------------------------------------
         * MyStaticTestClass test = new MyStaticTestClass();
         * 
         * Show in the console:
         * "Init in the static constructor"
         * "Init in the instance constructor"
         */
        static MyStaticTestClass()
        {
            Console.WriteLine("Init in the static constructor");
            CurrentDate = DateTime.Now;
        }

        public static void SayHello()
        {
            Console.WriteLine($"Hello! I'm { Name } - { CurrentDate.ToShortDateString() }");
        }

        public MyStaticTestClass()
        {
            text = "Init in the instance constructor";
            Console.WriteLine(text);
        }
    }
}
