using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2ConsoleApp
{
    abstract class BaseWorker : IComparable<BaseWorker>
    {
        public abstract decimal CalculateMonthSalary();

        //public int Compare(object x, object y)
        //{
        //    var x1 = (BaseWorker)x;
        //    var y1 = (BaseWorker)y;

        //    if (x1.CalculateMonthSalary() > y1.CalculateMonthSalary())
        //        return 1;
        //    else
        //        return -1;
        //}


        public int CompareTo(BaseWorker other)
        {
            if (this.CalculateMonthSalary() > other.CalculateMonthSalary())
                return 1;
            else if (this.CalculateMonthSalary() < other.CalculateMonthSalary())
                return -1;
            else
                return 0;
        }
    }
}
