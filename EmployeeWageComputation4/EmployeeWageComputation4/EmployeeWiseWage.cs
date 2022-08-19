namespace EmployeeWageComputation4
{
    public class EmployeeWiseWage
    {
        public string CompanyName;
        public byte WorkHoursFullDay;
        public byte WorkHoursPartDay;
        public byte WorkHoursPerMonth;
        public byte WorkDaysPerMonth;
        public int EmployeeWagePerHour;

        public int CompanyDailyWage = 0;
        public int CompanyMonthlyWage = 0;
        public byte AttendanceChk;

        public EmployeeWiseWage(string companyName, byte workHoursFullDay, byte workHoursPartDay, byte workHoursPerMonth, byte workDaysPerMonth, int employeeWagePerHour)
        {
            CompanyName = companyName;
            WorkHoursFullDay = workHoursFullDay;
            WorkHoursPartDay = workHoursPartDay;
            WorkHoursPerMonth = workHoursPerMonth;
            WorkDaysPerMonth = workDaysPerMonth;
            EmployeeWagePerHour = employeeWagePerHour;
        }

        public int GetDailyWage()
        {
            var attendance = EmployeeAttendance.Attendance();



            switch (attendance)
            {
                case "Present": CompanyDailyWage = WorkHoursFullDay * EmployeeWagePerHour; AttendanceChk = 2; break;
                case "Part Present": CompanyDailyWage = WorkHoursPartDay * EmployeeWagePerHour; AttendanceChk = 1; break;
                default: CompanyDailyWage = 0; break;
            }
            return CompanyDailyWage;
        }

        public int GetMonthlyWage()
        {
            var workHours = 0;
            var days = 0;

            while (workHours < WorkHoursPerMonth && days < WorkDaysPerMonth)
            {
                var dailyWage = GetDailyWage();
                if (AttendanceChk == 2)
                    workHours += WorkHoursFullDay;
                else if (AttendanceChk == 1)
                    workHours += WorkHoursPartDay;

                CompanyMonthlyWage += dailyWage;
                days++;
            }

            return CompanyMonthlyWage;
        }
    }
}
