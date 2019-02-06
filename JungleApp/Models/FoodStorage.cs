using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public class FoodStorage
    {
        //TODO: ArrayList
        /*
         *It’s an array of objects which can grow and shrink its size dynamically. Unlike arrays, an ArrayList can hold
         * data of multiple data types. It can be accessed by its index. Inserting and deleting an element at the middle
         * of an ArrayList is more costly than inserting or deleting an element at the end an ArrayList
         * */

        private ArrayList Snacks { get; set; }

        //TODO: HashTable
        /*
         * Hashtable stores each element of a collection in a pair of key/values. It optimizes the lookups by computing
         * the hash key and stores it to access the value against it.
         */
        internal Hashtable Drinks { get; set; }

        //TODO: Queue
        //It stores and retrieves objects in FIFO (First In, First Out) order

        public Queue<string> MaintenanceDays { get; set; }

        //TODO: Stack
        //It stores and retrieves objects in LIFO (Last In, First Out) order

        public Stack<string> Providers { get; set; }

        //TODO: Dictionary
        /*
         *  It’s a type-safe collection of key/value pairs. 
         *  Each key in dictionary must be unique and can store multiple values against the same key.
         *  Dictionary<TKey, TValue> is much faster than Hashtable.
         */
        public Dictionary<string, List<string>> MaintenancePersonnelByDay { get; set; }



        public FoodStorage()
        {
            Snacks = new ArrayList();
            Drinks = new Hashtable();
            MaintenanceDays = new Queue<string>();
            Providers = new Stack<string>();
            MaintenancePersonnelByDay = new Dictionary<string, List<string>>();
        }

        internal void StoreSnack(object snack)
        {
            Debug.WriteLine($"I'm storing  a snack");
            Snacks.Add(snack);
        }

        internal void ShowSnacks()
        {
            foreach (var snack in Snacks)
            {
                Debug.WriteLine($"Snack: { snack }");
            }
        }



    }
}
