using System;

namespace EmployeeWageComputation4
{
    public enum Variable : byte
    {
        EmployeePresent = 1,
        EmployeePartPresent = 2,
        WorkHoursFullDay = 8,
        WorkHoursPartDay = 4,
        WorkHoursPerMonth = 100,
        WorkDaysPerMonth = 20,
        EmployeeWagePerHour = 20
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n\n Welcome to Employee Wage Computation Program");

            // UC 1 to 5

            Console.WriteLine("\n >>>>>> Employee MonthlyWage Calculation <<<<<< ---- ${0}", MonthlyWage.MonthlyWageCalculation());

            // UC 6 and 7 

            Console.WriteLine(" >>>>>> Employee MonthlyWage Calculation With Hours or Days Completion Criteria <<<<<< ---- ${0} \n\n", MonthlyWageWithCriteria.MonthlyWageWithCriteriaCalculation()); // UC 6 and 7

            //UC 8

            Console.Write(" >>>> Employee Wise Monthly Wage <<<< \n\n Enter Company Name : "); var cName = Console.ReadLine();
            Console.Write(" Enter Work hours a day : "); var hoursDay = Convert.ToByte(Console.ReadLine());
            Console.Write(" Enter Work hours for HALF day : "); var hoursPartDay = Convert.ToByte(Console.ReadLine());
            Console.Write(" Enter Maximum Work HOURS per month : "); var hoursMonth = Convert.ToByte(Console.ReadLine());
            Console.Write(" Enter Maximum Work DAYS per month : "); var daysMonth = Convert.ToByte(Console.ReadLine());
            Console.Write(" Enter Hourly Wage : "); var wage = Convert.ToByte(Console.ReadLine());
            var company1 = new EmployeeWiseWage(cName, hoursDay, hoursPartDay, hoursMonth, daysMonth, wage);
            Console.WriteLine("\n >>> Employee was paid $ {0} by {1} after completing a month", company1.GetMonthlyWage(), company1.CompanyName);
        }
    }
}

