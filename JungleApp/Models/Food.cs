﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public class Food : IFood
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
    }
}
