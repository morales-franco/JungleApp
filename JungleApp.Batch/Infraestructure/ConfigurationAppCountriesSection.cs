using System.Configuration;

namespace JungleApp.Batch.Infraestructure
{
    //Configuration of AppCountriesSection in the app.config
    class ConfigurationAppCountriesSection : ConfigurationSection
    {
        private const string _CountriesCollectionName = "Countries";

        [ConfigurationProperty(_CountriesCollectionName)]
        [ConfigurationCollection(typeof(CountriesCollection), AddItemName = "Country")]
        public CountriesCollection Countries {
            get
            {
                return (CountriesCollection)base[_CountriesCollectionName];
            }
        }

    }

    public class CountriesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CountryConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CountryConfigurationElement)element).Name;
        }
    }

    public class CountryConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("continent", IsRequired = true)]
        public string Continent
        {
            get { return (string)this["continent"]; }
            set { this["continent"] = value; }
        }
    }
}
