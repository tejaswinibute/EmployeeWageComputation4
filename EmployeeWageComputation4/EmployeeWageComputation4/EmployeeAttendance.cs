namespace EmployeeWageComputation4
{
    public class EmployeeAttendance
    {
        public static string Attendance()
        {
            Random random = new Random();
            int empCheck = random.Next(0, 3); // random numbers between 0 and 2, not including 2

            string status;

            if (empCheck == (byte)Variable.EmployeePresent)
                status = "Present";
            else if (empCheck == (byte)Variable.EmployeePartPresent)
                status = "Part Present";
            else
                status = "Absent";

            return status;
        }
    }
}