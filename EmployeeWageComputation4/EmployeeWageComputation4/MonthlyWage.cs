namespace EmployeeWage
{
    public class MonthlyWage
    {
        public static int MonthlyWageCalculation()
        {
            var countDays = 0;
            var monthlyWage = 0;
            while (countDays < (byte)Variable.WorkDaysPerMonth)
            {
                var dailyWage = DailyWage.DailyWageCalculation();
                monthlyWage += dailyWage;
                countDays++;
            }
            return monthlyWage;
        }
    }
}
