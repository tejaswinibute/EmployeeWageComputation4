namespace EmployeeWage
{
    public class DailyWage
    {
        public static int DailyWageCalculation()
        {
            int dailyWage;
            var status = EmployeeAttendance.Attendance();

            switch (status)
            {
                case "Present": dailyWage = (byte)Variable.WorkHoursFullDay * (byte)Variable.EmployeeWagePerHour; break;
                case "Part Present": dailyWage = (byte)Variable.WorkHoursPartDay * (byte)Variable.EmployeeWagePerHour; break;
                default: dailyWage = 0; break;
            }
            return dailyWage;
        }
    }
}