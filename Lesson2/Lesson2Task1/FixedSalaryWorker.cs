using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2ConsoleApp
{
    class FixedSalaryWorker : BaseWorker
    {
        
        public FixedSalaryWorker(GradeEnum grade)
        {
            _workerGrade = grade;
        }

        //Уровень работника, от которого зависит зарплата
        private readonly GradeEnum _workerGrade;


        public override decimal CalculateMonthSalary()
        {
            var result = 0M;

            switch (_workerGrade)
            {
                case GradeEnum.CheapWorker:
                    result = 100;
                    break;
                case GradeEnum.NormalWorker:
                    result = 200;
                    break;
                case GradeEnum.ExpensiveWorker:
                    result = 300;
                    break;
            }

            return result;
        }
    }
}
