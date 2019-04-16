using JungleApp.Batch.Entities;
using JungleApp.Batch.Infraestructure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JungleApp.Batch.Services
{
    class CountryService
    {
        public List<Country> GetCountriesFromAppSettings()
        {
            return new List<Country>()
            {
                new Country("Argentina", ConfigurationManager.AppSettings["Argentina"]),
                new Country("New Zealand", ConfigurationManager.AppSettings["New Zealand"]),
                new Country("Spain", ConfigurationManager.AppSettings["Spain"]),
                new Country("Africa", ConfigurationManager.AppSettings["Africa"]),
                new Country("South Africa", ConfigurationManager.AppSettings["South Africa"]),
            };
        }

        public List<Country> GetCountriesFromKeyValuePairCustomSection()
        {
            var countries = new List<Country>();
            var appCountriesCollection = ConfigurationManager.GetSection("AppCountries") as NameValueCollection;

            foreach (var countryKey in appCountriesCollection.AllKeys)
                countries.Add(new Country(countryKey, appCountriesCollection[countryKey]));

            return countries;
        }

        public List<Country> GetCountriesFromAppContriesSection()
        {
            var countries = new List<Country>();
            var appCountriesSection = ConfigurationManager.GetSection("AppCountriesSection") as ConfigurationAppCountriesSection;

            foreach (CountryConfigurationElement countryElement in appCountriesSection.Countries )
                countries.Add(new Country(countryElement.Name, countryElement.Continent));

            return countries;
        }

    }
}
