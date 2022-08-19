namespace EmployeeWageComputation4
{
    public class MonthlyWageWithCriteria
    {
        public static int MonthlyWageWithCriteriaCalculation()
        {
            var workHours = 0;
            var days = 0;
            var monthlyWageWithCriteria = 0;

            while (workHours < (byte)Variable.WorkHoursPerMonth && days < (byte)Variable.WorkDaysPerMonth)
            {
                var dailyWage = DailyWage.DailyWageCalculation();
                if (dailyWage >= (byte)Variable.WorkHoursFullDay * (byte)Variable.EmployeeWagePerHour)
                    workHours += (byte)Variable.WorkHoursFullDay;
                else if (dailyWage < (byte)Variable.WorkHoursPartDay * (byte)Variable.EmployeeWagePerHour)
                    workHours += (byte)Variable.WorkHoursPartDay;

                monthlyWageWithCriteria += dailyWage;

                days++;
            }

            return monthlyWageWithCriteria;
        }
    }
}

 