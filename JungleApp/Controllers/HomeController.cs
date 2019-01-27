using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JungleApp.Models;

namespace JungleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*
         * Action Method
         */
        public IActionResult ReadonlyKeyword()
        {
            var dog = new Dog(DateTime.Now, "Pitbull", "Rambito");

            dog.Name = "Diana";
            dog.Breed = "Bulldog";

            /*
             * Readonly variables! They can only be asssigned in a constructor or declaration in the class
             */
            //dog.Birth = DateTime.Now;
            //dog.Color = "Green";

            /*
             * Constant !
             * DefaultMood is a constant, its value can't be changed in execution time. 
             * This variable can only be assigned in its declaration.
             */
            //Dog.DefaultMood = "Bored";

            return View(dog);
        }


    }
}
