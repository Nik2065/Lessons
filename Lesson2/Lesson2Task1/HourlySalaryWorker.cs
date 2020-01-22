using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2ConsoleApp
{
    class HourlySalaryWorker : BaseWorker
    {
        public HourlySalaryWorker(decimal hourlyRate)
        {
            _hourlyRate = hourlyRate;
        }

        private readonly decimal _hourlyRate;


        //может стоит как-то узнать месяц, за который расчитываем зарплату
        public override decimal CalculateMonthSalary()
        {
            return (20.8M * 8M * _hourlyRate);
        }
    }
}
