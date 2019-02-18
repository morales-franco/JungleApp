using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{

    //TODO: Generic class
    /*
     * Generic restrictions
     * where T : struct Type “T” must be a value type
     * where T : class Type “T” must be a reference type
     * where T : new() Type “T” must has a definition of PUBLIC DEFAULT CONSTRUCTOR (if I just have a constructor:  "Myclass(string value)" and not a default constructor: "Myclass()" --> ERROR)
     * where T : U Type “T” must be or child of type “U
     * where T : interfaceName Type “T” must be or implement a specified interface
     */
    public class GenericAnimal<T, E> where E: IFood
    {
        private List<E> _FoodEaten;
        private T _GenericProperty { get; set; }

        public GenericAnimal(T genericValue)
        {
            _GenericProperty = genericValue;
            _FoodEaten = new List<E>();
        }

       

        public T GetMyGenericProperty()
        {
            return _GenericProperty;
        }

        internal void EatFood(E food)
        {
            _FoodEaten.Add(food);
            Debug.WriteLine($"I'm eating {food.Name}");
        } 

        public void DrinkWater<D>(D drink) where D: class, IDrink, new()
        {

            //Check if drink implement IFood
            if(drink is IFood)
            {
                var food = drink as IFood;
                Debug.WriteLine($"I want to drink, not eat {food.Name} !!!");
            }
            else
            {
                Debug.WriteLine($"I'm drinking { drink.Description }({ typeof(D).Name })");
            }
        }

    }
}
