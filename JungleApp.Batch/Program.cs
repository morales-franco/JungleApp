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
            TestConfigSections();
            Console.Read();
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
