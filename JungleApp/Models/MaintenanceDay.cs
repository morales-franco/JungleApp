using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    //TODO: IComparable
    /*
     * IComparable and IComparable<T> are interfaces used to define a comparison method for a type to order or sort its
     * instances. The CompareTo method returns an Int32 that has one of three values which have following meaning:
     * •	 Return zero, current instance will occur in the same position.
     * •	 Less than zero, current instance precedes the object specified by the CompareTo method in the sort order.
     * •	 Greater than zero, current instance follows the object specified by the CompareTo in the sort order.
     */
    public class MaintenanceDay : IMaintenanceDay,
                                  IComparable
    {
        public DateTime Day { get; set; }
        public int Priority { get; set; }

        public MaintenanceDay(DateTime day, int priority = 0)
        {
            Day = day;
            Priority = priority;
        }

        public int CompareTo(object obj)
        {
            MaintenanceDay next = (MaintenanceDay)obj;
            return Priority >= next.Priority ? 1 : -1;
        }
    }
}
