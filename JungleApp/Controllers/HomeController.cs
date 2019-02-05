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
            TestArray();
            TestDoWhile();
            TestRefAndOut();
            TestCat();
            return View();
        }

        private void TestCat()
        {
            Debug.WriteLine("############ TestConstructor ############");
            Cat miau = new Cat("Michi", "white");


            Debug.WriteLine("############ Test Extensions Methods ############");

            //TODO: Extensions string - Cat
            if (miau.Name.IsMichiOrEmpty())
                miau.SayHelloFromTheExtension();

            Debug.WriteLine("############ Test Explicit User Defined Conversion ############");
            //TODO: explicit operator for conversion
            string catString = (string)miau;
            int catInt = (int)miau;

            Debug.WriteLine($"Explicit type Conversion - Cat to string {catString} - Cat to Int { catInt }");

            Debug.WriteLine("############ Test Implicit User Defined Conversion ############");
            //TODO: implicit operator for conversion
            List<string> me = miau;
            me.ForEach(m => Debug.WriteLine($"Implicit type Conversion - {m}"));

            Debug.WriteLine("############ Test Access Specifiers ############");

            miau.Height = 1; //Internal
            //miau.Weight = 10; //Protected only class and child class
            miau.Lenght = 3; //protected internal
            miau.IsVaccinated = false; //public

        }

        private void TestDoWhile()
        {
            Debug.WriteLine("############ TestDoWhile ############");
            var counter = 0;
            var animals = new string[] { "dog", "cat", "lion" };

            do
            {
                Debug.WriteLine($"Animal {counter}: {animals[counter]}");
                counter++;

            } while (counter < animals.Length );
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

        private void TestArray()
        {
            Debug.WriteLine("############ TestArray ############");
            int[] ages = new int[5]; //Declare size is required

            string[] animals = new string[5] { "dog", "cat", "lion", "panter", "bird" };

            for (int i = 0; i < 5; i++)
            {
                ages[i] = i + 10;
            }

            Debug.WriteLine("############ Array 1 dimension ############");
            for (int i = 0; i < 5; i++)
            {
                Debug.WriteLine($"Age: { ages[i] } - Animal { animals[i]}");
            }

            //2 dimension Array

            Debug.WriteLine("############ Array 2 dimension ############");
            string[,] matrizAnimals = new string[2, 3]
            {
                { "dog", "cat", "sharp"},
                { "bird", "lion", "dolphin"}
            };

            //array.GetLength(dimension) --> Obtiene lenght de una dimensión del  array.
            for (int row = 0; row < matrizAnimals.GetLength(0); row++)
            {
                for (int column = 0; column < matrizAnimals.GetLength(1); column++)
                {
                    Debug.WriteLine($"Row: { row } - Column { column } - Value: { matrizAnimals[row,column] }");
                } 

            }

            //Jagged Array --> Arrays of arrays

            Debug.WriteLine("############ Jagged Arrays ############");

            string[][] stuffs = new string[2][]
            {
                new string[2]{ "Desk", "Chair" },
                new string[4]{ "Red", "Orange", "Violet", "Yellow" }
            };


            string[][] stuffs2 = {
                new string[2]{ "Desk", "Chair" },
                new string[4]{ "Red", "Orange", "Violet", "Yellow" }
            };

            string[][] stuffs3 = new string[2][];
            stuffs3[0] = new string[2] { "Desk", "Chair" };
            stuffs3[1] = new string[4] { "Red", "Orange", "Violet", "Yellow" };

            //stuffs = stuffs2 = stuffs3

            for (int r = 0; r < stuffs.Length; r++)
            {
                for (int c = 0; c < stuffs[r].Length; c++)
                {
                    Debug.WriteLine($"Row: { r } - Column { c } - Value: { stuffs[r][c] }");
                }
            }
        }

        private void TestRefAndOut()
        {
            Debug.WriteLine("############ TestRefAndOut ############");

            Debug.WriteLine("############ REF ############");
            int workItems = 0;

            //Variables pass like value for definition
            AddWorkItem(workItems);
            Debug.WriteLine($"AddWorkItem() { workItems}");

            //we pass workItems for reference --> pass a memory address
            AddWorkItemRef(ref workItems);
            Debug.WriteLine($"AddWorkItemRef() { workItems}");

            //Error! Ref variable is required initialize the variable!
            //int workItemsFM;
            //AddWorkItemRef(ref workItemsFM);


            Debug.WriteLine("############ OUT ############");
            //Out work same as ref keyword works but Out keyword permit to pass a non-initialized variable

            int workItemsFM;
            ResetWorkItemsOut(out workItemsFM);

            Debug.WriteLine($"OUT - ResetWorkItems() { workItemsFM}");

            Debug.WriteLine("############ Objects OUT & REF ############");

            //Wrong! Initialize object variable is required!
            //Dog puppy;
            //InitPuppy(puppy);

            //Init puppy
            Dog puppy = new Dog(DateTime.Now, "Pitbull", "Rambito");
            puppy.FavoriteFoods = new List<Food>
            {
                new Food{ FoodId = 1, Name="Chicken" },
                new Food{ FoodId = 2, Name="Meat" },
            };

            Debug.WriteLine($"Default Init - Dog Name: { puppy.Name } ({puppy.Name.GetHashCode()}) - Breed: { puppy.Breed} - Favourites Foods: { string.Join(",", puppy.FavoriteFoods.Select(f => f.Name).ToArray()) } - Hash code: { puppy.GetHashCode()} - Hash code Foods: { puppy.FavoriteFoods.GetHashCode()}");

            //Try instance puppy inside the method SetAsDiana() - try relocate puppy variable
            SetAsDiana(puppy);

            //There isn't any change!
            //We cant reset memory address 
            Debug.WriteLine($"SetAsDiana() - Dog Name: { puppy.Name } ({puppy.Name.GetHashCode()}) - Breed: { puppy.Breed} - Favourites Foods: { string.Join(",", puppy.FavoriteFoods.Select(f => f.Name).ToArray()) } - Hash code: { puppy.GetHashCode()} - Hash code Foods: { puppy.FavoriteFoods.GetHashCode()}");

            //works great! You can change memory adddress in properties 
            //Object is passed by value puppy you cant reloated de object but you can instance, realocate or modify his properties
            ChangeFavoritesFoods(puppy);
            Debug.WriteLine($"ChangeFavoritesFoods() - Dog Name: { puppy.Name } ({puppy.Name.GetHashCode()}) - Breed: { puppy.Breed} - Favourites Foods: { string.Join(",", puppy.FavoriteFoods.Select(f => f.Name).ToArray()) } - Hash code: { puppy.GetHashCode()} - Hash code Foods: { puppy.FavoriteFoods.GetHashCode()}");

            //Ref
            SetAsDianaRef(ref puppy);

        }

        private void SetAsDianaRef(ref Dog puppy)
        {
            puppy = new Dog(DateTime.Now, "Very active Pitbull", "Diana");
            puppy.FavoriteFoods = new List<Food>
            {
                new Food{ FoodId = 3, Name="Pro plan" },
                new Food{ FoodId = 4, Name="Pedigree" },
            };
        }

        private void ChangeFavoritesFoods(Dog puppy)
        {
            puppy.Name = "Ranbón";
            puppy.FavoriteFoods = new List<Food>
            {
                new Food{ FoodId = 5, Name="Rice" },
                new Food{ FoodId = 6, Name="Plants" },
            };
        }

        private void SetAsDiana(Dog puppy)
        {
            puppy = new Dog(DateTime.Now, "Very active Pitbull", "Diana");
            puppy.FavoriteFoods = new List<Food>
            {
                new Food{ FoodId = 3, Name="Pro plan" },
                new Food{ FoodId = 4, Name="Pedigree" },
            };
        }



        private void ResetWorkItemsOut(out int workItemsFM)
        {
            workItemsFM = 0;
            workItemsFM = workItemsFM + 1;
        }

        private void AddWorkItemRef(ref int workItems)
        {
            workItems = workItems + 1;
        }

        private void AddWorkItem(int workItems)
        {
            workItems = workItems + 1;
        }
    }
}
