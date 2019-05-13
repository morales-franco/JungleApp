using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models.PatternMatching
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public string Country { get; set; }
        private readonly eClassificationAnimal Classification;

        public string WhatAnimal => this switch
        {
            Lion lion=> $"I'm a lion -  { lion.Name } from { lion.Country }!",
            Cow _ => "I'm a cow!",
            Pig _ => "I'm a Pig!",
            _ => "I'm a unknown animal!"
        };

        public bool HideFromOtherAnimals => this switch
        {
            Lion _ => false,
            _      => true
        };


        public Animal(string name, eClassificationAnimal classification, string country)
        {
            Name = name;
            Classification = classification;
            Country = country;
        }

        public void Deconstruct(out string name, out eClassificationAnimal classification, out string country)
        {
            name = Name;
            classification = Classification;
            country = Country;
        }

        public eClassificationAnimal GetClassificationAnimal()
        {
            return Classification;
        }

        public abstract void SayHello();

        public abstract eFavoriteFood GetFavouriteFood();

    }
}
