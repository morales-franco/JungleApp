using JungleApp.Batch.Entities;
using JungleApp.Batch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleApp.Batch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------- Welcome ----------");
            //TestConfigSections();
            //TestReflection();
            //TestStaticClass();
            //TestTasks();
            TestLazy();

            
            Console.Read();
        }

        private static void TestLazy()
        {
            MyLazyAuthor author = new MyLazyAuthor("Fran");
            Console.WriteLine($"Author Name: {author.Name}");

            Console.WriteLine("Now I invoke the Books property..");
            //Load books in lazy form!
            var books = author.Books.Value;

            foreach (var book in books)
                Console.WriteLine($"Book Name: {book.Name}");
        }

        private static void TestStaticClass()
        {
            ShowTitle("---------- TEST STATIC CLASS----------");
            MyStaticTestClass test = new MyStaticTestClass();
        }

        private static void TestTasks()
        {
            ShowTitle("---------- TEST TASKS ----------");
            TaskServices taskServices = new TaskServices();
            taskServices.ExecuteConversation();
        }

        private static void TestReflection()
        {
            ShowTitle("---------- TEST REFLECTION ----------");

            CommunicatorService communicatorService = new CommunicatorService();

            //TODO: Getting type from String - Instance this type in a class [Type lives in a external assembly]
            Console.ForegroundColor = ConsoleColor.Magenta;
            ShowTitle("--------- Getting type from String - Instance this type in a class [Type lives in a external assembly] ---------");

            //TODO: AssemblyQualifiedName: namespaces.class, assemblyName: Integra.Communicator.Zk.CommunicatorApi,Integra.Communicator.Zk
            var communicator = communicatorService.GetCommunicator("Integra.Communicator.Zk.CommunicatorApi,Integra.Communicator.Zk");

            foreach (var user in communicator.GetUsers())
                Console.WriteLine($"Identifier: { user.Identifier }");
        }

        private static void TestConfigSections()
        {
            //TODO: Custom sections in App.Config
            ShowTitle("---------- TEST CONFIG SECTIONS ----------");

            CountryService countryService = new CountryService();

            Console.ForegroundColor = ConsoleColor.Magenta;
            ShowTitle("--------- Approach 1 : App Settings ---------");
            foreach (var country in countryService.GetCountriesFromAppSettings())
                Console.WriteLine($"Country: { country.Name } - Continent: { country.Continent }");

            Console.ForegroundColor = ConsoleColor.Cyan;
            ShowTitle("--------- Approach 2 : using Built-in: NameValueSectionHandler - using Key/value pair inside Custom Section ---------");
            foreach (var country in countryService.GetCountriesFromKeyValuePairCustomSection())
                Console.WriteLine($"Country: { country.Name } - Continent: { country.Continent }");

            Console.ForegroundColor = ConsoleColor.Red;
            ShowTitle("--------- Approach 3 : using custom Section with our own types to bring more information than key value pair ---------");
            foreach (var country in countryService.GetCountriesFromAppContriesSection())
                Console.WriteLine($"Country: { country.Name } - Continent: { country.Continent }");

        }

        private static void ShowTitle(string title)
        {
            Console.WriteLine();
            Console.WriteLine(title);
           
        }
    }
}
