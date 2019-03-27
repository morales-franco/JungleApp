using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{

    public class Mock
    {
        delegate int AddNumber(int x, int y);


        public Mock()
        {
            
        }

        public int MockSum(int numberA, int numberB)
        {
            AddNumber add = delegate (int number1, int number2)
            {
                return number1 + number2;
            };

            var result = add(numberA, numberB);
            return result;
        }


    }
}
