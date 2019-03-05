using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JungleApp.Models;
using System.Collections;
using JungleApp.Extensions;
using JungleApp.Services;
using System.Dynamic;

namespace JungleApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Chapter2();
            Chapter3();
            Chapter4();
            Chapter5();
            Chapter10();
            Chapter11();
            Chapter14();
            ExceptionTest();
            DynamicTest();
            return View();
        }

        private void DynamicTest()
        {
            //TODO: Dynamic types
            Debug.WriteLine("############ Dynamic Types ############");

            Debug.WriteLine("#### Viewbag is a Expand Object [built-in framework]) ####");

            ViewBag.FootballTeamName = "Jungle Team Futbol Club";
            ViewBag.FootballTeamCountPlayers = 22;
            ViewBag.FootballTeamCouch = "Pinguin X";

            Debug.WriteLine($"*Viewbag - FootballTeamName:  { ViewBag.FootballTeamName }");
            Debug.WriteLine($"*Viewbag - FootballTeamCountPlayers:  { ViewBag.FootballTeamCountPlayers }");
            Debug.WriteLine($"*Viewbag - FootballTeamCouch:  { ViewBag.FootballTeamCouch }");

            Debug.WriteLine("#### ExpandObject ####");
            dynamic footballTeam = new ExpandoObject();
            footballTeam.FootballTeamName = "Jungle Team Futbol Club";
            footballTeam.FootballTeamCountPlayers = 22;
            footballTeam.FootballTeamCouch = "Pinguin X";

            Debug.WriteLine($"*ExpandoObject - FootballTeamName:  { footballTeam.FootballTeamName }");
            Debug.WriteLine($"*ExpandoObject - FootballTeamCountPlayers:  { footballTeam.FootballTeamCountPlayers }");
            Debug.WriteLine($"*ExpandoObject - FootballTeamCouch:  { footballTeam.FootballTeamCouch }");

            Debug.WriteLine("#### DynamicObject ####");
            dynamic footballTeamObj = new FootballTeamDynamic();
            footballTeamObj.FootballTeamName = "Jungle Team Futbol Club";
            footballTeamObj.FootballTeamCountPlayers = 22;
            footballTeamObj.FootballTeamCouch = "Pinguin X";

            Debug.WriteLine($"*DynamicObject - FootballTeamName:  { footballTeamObj.FootballTeamName }");
            Debug.WriteLine($"*DynamicObject - FootballTeamCountPlayers:  { footballTeamObj.FootballTeamCountPlayers }");
            Debug.WriteLine($"*DynamicObject - FootballTeamCouch:  { footballTeamObj.FootballTeamCouch }");

            Debug.WriteLine("#### Dynamic ####");
            dynamic teamDynamic = new
            {
                FootballTeamName = "Jungle Team Futbol Club",
                FootballTeamCountPlayers = 22,
                FootballTeamCouch = "Pinguin X"
            };

            Debug.WriteLine($"*dynamic - FootballTeamName:  { teamDynamic.FootballTeamName }");
            Debug.WriteLine($"*dynamic - FootballTeamCountPlayers:  { teamDynamic.FootballTeamCountPlayers }");
            Debug.WriteLine($"*dynamic - FootballTeamCouch:  { teamDynamic.FootballTeamCouch }");
        }

        private void ExceptionTest()
        {
            //TODO: Exceptions
            Debug.WriteLine("############ Exceptions ############");
            var testService = new TestService();
            try
            {
                testService.ThrowOriginalException();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

            try
            {
                testService.ThrowExceptionWithResetStackTrace();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

            try
            {
                testService.ThrowCustomException();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void Chapter14()
        {
            Debug.WriteLine("############ Reflection ############");
            ReflectorAnimal reflector = new ReflectorAnimal();
            reflector.Explorer();
        }

        private void Chapter11()
        {
            TravelBus bus = new TravelBus();
            bus.Send(new Provider()
            {
                Age = 28,
                Birth = DateTime.Now,
                CompletedName = "Chris M",
                ProviderId = 1,
                Stuffs = new List<string>() { "Bag", "t-shirts", "pants", "white hat", "laptop" }
            });
        }

        private void Chapter10()
        {
            AnimalFileExplorer explorer = new AnimalFileExplorer();
            explorer.Explorer();
        }

        private void Chapter5()
        {
            Debug.WriteLine("############ Delegate ############");
            var tourist = new Tourist();
            tourist.Run();
        }

        private void Chapter4()
        {
            /*
             * TODO: Boxing/Unboxing 
             * Cast type to object and object to type
             * Boxing and Unboxing are very expensive in terms of computation operations for a processor. 
             * Therefore,it is best to avoid using value types where they must be boxed and unboxed many times
             */
            Debug.WriteLine("############ Boxing/Unboxing ############");
            Debug.WriteLine("## Boxing ##");
            int myRandomNumber = 98;
            object boxedAge = myRandomNumber;

            Debug.WriteLine("## Unboxing ##");
            int unboxedAge = (int)boxedAge;


            Debug.WriteLine("############ Generics ############");
            var genericAnimal_String = new GenericAnimal<string, Food>("I'm a generic value");
            var genericAnimal_Int = new GenericAnimal<int, Food>(1234);

            var genericValueString = genericAnimal_String.GetMyGenericProperty();
            var genericValueInt = genericAnimal_Int.GetMyGenericProperty();

            Debug.WriteLine($"I'm a Generic Animal <string> - value: { genericValueString} ");
            Debug.WriteLine($"I'm a Generic Animal <int> - value: { genericValueInt} ");

            genericAnimal_String.EatFood(new Food() { FoodId = 1, Name = "Meat" });
            //genericAnimal_String.DrinkWater<Food>(new Food() { FoodId = 1, Name = "Meat" }); --> Food Not implement IDrink
            genericAnimal_String.DrinkWater<Drink>(new Drink("water"));
            genericAnimal_String.DrinkWater<Soap>(new Soap("soap", "chicken soap"));//Soap Not implement IDrink & IFood

            Debug.WriteLine("############ Collection ############");
            var foodStorage = new FoodStorage();

            Debug.WriteLine("############ Array List ############");
            //ArrayList Can hold multiple data type
            foodStorage.StoreSnack(new Food() { FoodId = 1, Name = "Banana" });
            foodStorage.StoreSnack("Any food");
            foodStorage.StoreSnack(new Drink("water"));
            foodStorage.StoreSnack(10000);
            foodStorage.ShowSnacks();

            Debug.WriteLine("############ Hash Table ############");

            foodStorage.Drinks.Add("Drink1", "Orange Juice");
            foodStorage.Drinks.Add("Drink2", "Apple Juice");
            foodStorage.Drinks.Add(1, "Water");
            //Check - duplicate key
            if (!foodStorage.Drinks.ContainsKey(1))
                foodStorage.Drinks.Add(1, "Beer");
            else
                Debug.WriteLine("duplicate Key Drink 1");

            foodStorage.Drinks.Add("Soda", 1);
            foodStorage.Drinks.Add("Moe drink", new Drink() { Description = "strange water" });

            foreach (DictionaryEntry drink in foodStorage.Drinks)
            {
                Debug.WriteLine($"Drink Key { drink.Key } - Value { drink.Value }");
            }

            Debug.WriteLine("############ Queue ############");
            foodStorage.MaintenanceDays.Enqueue("Monday");
            foodStorage.MaintenanceDays.Enqueue("Wednesday");
            foodStorage.MaintenanceDays.Enqueue("Friday");
            foodStorage.MaintenanceDays.Enqueue("Sunday");

            Debug.WriteLine($"Maintenance days : { foodStorage.MaintenanceDays.Count } count");

            //Show First element but not remove it
            Debug.WriteLine($"Peek: First Maintenance day : { foodStorage.MaintenanceDays.Peek() }");
            //Remove First
            Debug.WriteLine($"Dequeue: First Maintenance day : { foodStorage.MaintenanceDays.Dequeue() }");


            Debug.WriteLine($"Dequeu: Maintenance days : { foodStorage.MaintenanceDays.Count } count");

            foreach (var day in foodStorage.MaintenanceDays)
            {
                Debug.WriteLine($"Maintenance days : { day }");
            }

            var totalMaintenanceDays = foodStorage.MaintenanceDays.Count;
            for (int i = 0; i < totalMaintenanceDays; i++)
            {
                Debug.WriteLine($"Dequeue : { foodStorage.MaintenanceDays.Dequeue() }");
            }

            Debug.WriteLine($"Maintenance days : { foodStorage.MaintenanceDays.Count } count");

            Debug.WriteLine("############ Stack ############");

            for (int i = 1; i <= 5; i++)
                foodStorage.Providers.Push($"Provider { i }");

            Debug.WriteLine($"Providers : { foodStorage.Providers.Count } count");

            var totalProviders = foodStorage.Providers.Count;
            for (int i = 0; i < totalProviders; i++)
            {
                Debug.WriteLine($"Pop Provider: { foodStorage.Providers.Pop() }");
            }

            Debug.WriteLine($"Providers : { foodStorage.Providers.Count } count");

            Debug.WriteLine("############ Dictionary ############");
            foodStorage.MaintenancePersonnelByDay.Add("Monday", new List<string>() { "Fran", "Pau" });

            if (foodStorage.MaintenancePersonnelByDay.ContainsKey("Monday"))
                foodStorage.MaintenancePersonnelByDay.Add("Tuesday", new List<string>() { "Lean", "Killyou" });

            foreach (KeyValuePair<string, List<string>> dataMaintenance in foodStorage.MaintenancePersonnelByDay)
            {
                Debug.WriteLine($"Day : { dataMaintenance.Key } - Maintenance Personnel { string.Join(",", dataMaintenance.Value.Select(p => p).ToArray())  }");
            }

            Debug.WriteLine("############ Create my custom List - IEnumerable############");

            MondayList<MaintenanceDay> calendar = new MondayList<MaintenanceDay>();

            Debug.WriteLine("Inflate calendar with 14 days");
            for (int i = 1; i <= 14; i++)
            {
                calendar.Add(new MaintenanceDay(DateTime.Now.AddDays(i)));
            }

            Debug.WriteLine($"Calendar Total days: { calendar.Count() }");

            Debug.WriteLine("We iterate with foreach loop Calendar:");
            foreach (var mondayDay in calendar)
            {
                Debug.WriteLine($"Day: { mondayDay.Day.ToString("dd/MM/yyyy") } - { mondayDay.Day.DayOfWeek.ToString() }");
            }

            Debug.WriteLine("Now, We iterate with for loop & custom properties:");
            for (int i = 0; i < calendar.TrueLenght(); i++)
            {
                Debug.WriteLine($"Day: { calendar.GetByIndex(i).Day.ToString("dd/MM/yyyy") } - { calendar.GetByIndex(i).Day.DayOfWeek.ToString() }");
            }

            Debug.WriteLine("Magic! Exist many days!");

            Debug.WriteLine("############ IComparable and Sort ############");
            List<MaintenanceDay> calendarSort = new List<MaintenanceDay>()
            {
                new MaintenanceDay(DateTime.Now, 10),
                new MaintenanceDay(DateTime.Now, 3),
                new MaintenanceDay(DateTime.Now, 1),
                new MaintenanceDay(DateTime.Now, 6),
                new MaintenanceDay(DateTime.Now, 1),
                new MaintenanceDay(DateTime.Now, 8),
                new MaintenanceDay(DateTime.Now, 5)
            };

            foreach (var dayWithoutSort in calendarSort)
            {
                Debug.WriteLine($"Day without sort- Priority: { dayWithoutSort.Priority } ");
            }

            //TODO: Sort --> Use  IComparable implementation
            calendarSort.Sort();
            foreach (var dayWithSort in calendarSort)
            {
                Debug.WriteLine($"Day sort- Priority: { dayWithSort.Priority } ");
            }

            Debug.WriteLine("############ Control Spacing ############");

            string col1 = "123456789-";
            string col2 = "123456789-";

            Debug.WriteLine("col1 {0,10} | col2 {1, 10}", col1, col2);

        }

        private void Chapter3()
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

            Debug.WriteLine("############ Test Indexers ############");

            Debug.WriteLine($"Indexers - Encapsule array - Cat says: Today I eat:  { miau[0] } ");

            Debug.WriteLine("############ Test Interface ############");
            miau.AskForMoreFood();

            Debug.WriteLine("############ Test Polymorphism ############");

            Debug.WriteLine("#### Test Static Polymorphism ####");

            Debug.WriteLine("## Method Overloading ##");
            Debug.WriteLine("# By Length of Parameters #");
            miau.Eat();
            miau.Eat("fish");
            miau.Eat("fish1", "fish2");

            Debug.WriteLine("# By Type of Parameters #");
            miau.Eat(new Food() { FoodId = 1, Name = "super fish" });

            Debug.WriteLine("## Operator Overloading ##");

            Debug.WriteLine($"Cat { miau.Name } says: I have { miau.LivesLeft } lives left");
            miau++;
            miau++;
            Debug.WriteLine($"Cat { miau.Name } says: Now I have { miau.LivesLeft } lives left (overload ++)");

            Debug.WriteLine($"Cat { miau.Name } says: Compare 1 { miau < miau }  - Compare 2 { miau > miau } (overload < & >)");


            Debug.WriteLine("#### Test Dynamic Polymorphism ####");
            Debug.WriteLine("# Virtual methods #");
            miau.Move();
            Debug.WriteLine("# Abstract methods #");
            miau.Eat();

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

            } while (counter < animals.Length);
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
                    Debug.WriteLine($"Row: { row } - Column { column } - Value: { matrizAnimals[row, column] }");
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

        private void Chapter2()
        {
            TestArray();
            TestDoWhile();

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
