using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public interface IFood
    {
        int FoodId { get; set; }
        string Name { get; set; }
    }
}
