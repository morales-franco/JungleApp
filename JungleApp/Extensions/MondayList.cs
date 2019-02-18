using JungleApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Extensions
{
    //TODO:  Custom List - IEnumerable
    public class MondayList<T> : IEnumerable<T> 
        where T: IMaintenanceDay
    {
        private List<T> _Days = new List<T>();

        /*
         * When call MondayList<T> in a foreach loop, this loop calls GetEnumerator() for 
         * iterate the data.
         */
        public IEnumerator<T> GetEnumerator()
        {
            /*
             * In this case when MondayList is called for a foreach loop in each iteration for get a value.
             * foreach (var mondayDay in calendar){show(mondayDay)}
             * Iteration 1. Foreach call   MondayList<>GetEnumerator() for get the first value.
             *              When MondayList<>GetEnumerator() return DAY_1 a value with yield, the foreach continue.
             *              load mondayDay with DAY_1 and execute show(mondayDay)
             *              continue
             * Iteration 2. Foreach want to get the next value from calendar--> Call a MondayList<>GetEnumerator() for the next value.
             *              The for loop continue with the iteration and return other "yield return _Days[i]"
             *              Foreach Load mondayDay with yield return _Days[i] and continue.
             *          
             * It's similar a block in asyn programming. 
             * GetEnumerator() return a value with  yield return _Days[i] to Foreach a stop.
             * When Foreach iterate and it needs the next value the "for loop" in  GetEnumerator() continue and return other value with yield.
             *               
             * Count()  called at this method too
             */
            for (int i = 0; i < _Days.Count; i++)
            {
                if (_Days[i].Day.DayOfWeek == DayOfWeek.Monday)
                    yield return _Days[i]; //IEnumerator is inflate with these days.
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Add(T day)
        {
            _Days.Add(day);
        }

        internal int TrueLenght()
        {
            return _Days.Count;
        }

        internal T GetByIndex(int i)
        {
            return _Days[i];
        }
    }
}
