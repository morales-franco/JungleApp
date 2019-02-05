using JungleApp.Models;
using System.Diagnostics;

namespace JungleApp.Models  //Defined method in the same namespace of Cat
{
    public static class CatExtensions
    {
        /*
        * use a static method
        * this + type/class want extended
        * In this case we want extend Cat class
        */

        public static void SayHelloFromTheExtension(this Cat cat)
        {
            Debug.WriteLine("Miauu from Extensions!");
        }
    }
}
