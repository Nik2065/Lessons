using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var workers = new BaseWorker[6];
            workers[0] = new FixedSalaryWorker(GradeEnum.CheapWorker);
            workers[1] = new FixedSalaryWorker(GradeEnum.NormalWorker);
            workers[2] = new FixedSalaryWorker(GradeEnum.ExpensiveWorker);
            workers[3] = new HourlySalaryWorker(0.6M);
            workers[4] = new HourlySalaryWorker(0.7M);
            workers[5] = new HourlySalaryWorker(0.8M);

            Console.WriteLine("До сортировки");
            foreach (var w in workers)
                Console.WriteLine(w.CalculateMonthSalary());

            Array.Sort(workers);

            Console.WriteLine("После сортировки");
            foreach (var w in workers)
                Console.WriteLine(w.CalculateMonthSalary());

        }
    }

    
}
