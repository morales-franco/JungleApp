using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public class ReflectorAnimal
    {
        public void Explorer()
        {
            ReadInfoAssembly();
            ExplorerACat();

        }

        private void ExplorerACat()
        {
            Debug.WriteLine("############ Set and Get Values of classes using Reflection############");

            //TODO: Get And Set data with reflection
            Cat cat1 = new Cat("miau1", "white");
            cat1.LivesLeft = 10;

            //store metadata of Cat
            var catType = typeof(Cat);

            //Add BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public because LivesLeft is internal, if property is public, it isn't neccesary
            //var livesLeftProperty = catType.GetProperty("LivesLeft", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            //var livesLeft = livesLeftProperty.GetValue(cat1);

            //Debug.WriteLine($"Get value of LivesLeft Property by Reflection: { livesLeftProperty.Name } =  { livesLeft }");

            //livesLeftProperty.SetValue(cat1, 200);
            //Debug.WriteLine($"Set new value of LivesLeft Property by Reflection: { livesLeftProperty.Name } =  { livesLeft }");

            ////TODO: Invoke a method data with reflection
            //Debug.WriteLine("############ Invoke a method using Reflection############");

            //var methodInfo = catType.GetMethod("Eat");
            //methodInfo.Invoke(cat1, new object[] { "MEAT" });

            //TODO: Get Private methods with reflection
            Debug.WriteLine("############ Get Private Methods ############");

            var privateMethods = catType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var privateMethod in privateMethods)
            {
                Debug.WriteLine($"{ privateMethod.Name } = { privateMethod.GetValue(cat1) }");
            }

            //TODO: Get Statics  methods with reflection
            Debug.WriteLine("############ Get Static Methods ############");

            var staticMethods = catType.GetProperties(BindingFlags.Public | BindingFlags.Static);

            foreach (var staticMethod in staticMethods)
            {
                Debug.WriteLine($"{ staticMethod.Name }");
            }
        }

        private void ReadInfoAssembly()
        {
            Debug.WriteLine("############ Read Assembly info ############");
            //TODO: Get current loaded assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.FullName;
            Debug.WriteLine(assemblyName);

            //TODO: Get all types defined in a assembly
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                Debug.WriteLine($"Type Name: { type.Name }, Base Type { type.BaseType }");

                //TODO: Read metadata of class
                PropertyInfo[] properties = type.GetProperties();

                foreach (var property in properties)
                {
                    Debug.WriteLine($"{ property.Name  } has   { property.PropertyType } type");
                }

                MethodInfo[] methods = type.GetMethods();

                foreach (var method in methods)
                {
                    Debug.WriteLine($"Method Name: { method.Name  } return type:   { method.ReturnType } ");
                }


            }


        }
    }
}
