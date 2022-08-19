namespace EmployeeWageComputation4
{
    public class MultiCompanyWiseWage
    {
        public Dictionary<string, List<int>> CompanyDict = new Dictionary<string, List<int>>();

        public int CompanyDailyWage = 0;
        public int CompanyMonthlyWage = 0;
        public byte AttendanceChk;

        public void AddCompany()
        {
            Console.Write("\n Enter Company Name : "); var cName = Console.ReadLine();
            Console.Write(" Enter Work hours a day : "); var hoursDay = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Enter Work hours for HALF day : "); var hoursPartDay = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Enter Maximum Work HOURS per month : "); var hoursMonth = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Enter Maximum Work DAYS per month : "); var daysMonth = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Enter Hourly Wage : "); var wage = Convert.ToInt32(Console.ReadLine());

            var CompanyList = new List<int> { hoursDay, hoursPartDay, hoursMonth, daysMonth, wage, 0, 0 };

            CompanyDict.Add(cName.ToUpper(), CompanyList);
        }

        public void ViewCompanies()
        {
            foreach (var key in CompanyDict.Keys)
                Console.WriteLine(key);
        }

        public int GetDailyWage(string cName)
        {
            var attendance = EmployeeAttendance.Attendance();

            switch (attendance)
            {
                case "Present": CompanyDailyWage = CompanyDict[cName][0] * CompanyDict[cName][4]; AttendanceChk = 2; break;
                case "Part Present": CompanyDailyWage = CompanyDict[cName][1] * CompanyDict[cName][0]; AttendanceChk = 1; break;
                default: CompanyDailyWage = 0; break;
            }
            CompanyDict[cName][5] = CompanyDailyWage;
            return CompanyDailyWage;
        }

        public int GetMonthlyWage(string cName)
        {
            var workHours = 0;
            var days = 0;

            while (workHours < CompanyDict[cName][2] && days < CompanyDict[cName][3])
            {
                var dailyWage = GetDailyWage(cName);
                if (AttendanceChk == 2)
                    workHours += CompanyDict[cName][0];
                else if (AttendanceChk == 1)
                    workHours += CompanyDict[cName][1];

                CompanyMonthlyWage += dailyWage;
                days++;
            }
            CompanyDict[cName][6] = CompanyMonthlyWage;
            return CompanyMonthlyWage;
        }

        public void UserInteractions()
        {
            Console.WriteLine("\n\n >>>>>>>MULTIPLE COMPANIES WAGE CALCULATION<<<<<<<<<< ");
            Console.Write(" 1. Add Company \n 2. View Companies \n 3. Get Daily Wage \n 4. Get Monthly Wage \n 5. EXIT \n\n >>> Input desired action : "); var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    {
                        AddCompany();
                        Console.WriteLine("\n Press Enter to continue .."); Console.ReadLine(); UserInteractions();
                        break;
                    }
                case "2":
                    {
                        ViewCompanies();
                        Console.WriteLine("\n Press Enter to continue .."); Console.ReadLine(); UserInteractions();
                        break;
                    }
                case "3":
                    {
                        Console.Write("\n >>> Enter Company Name : "); string cName = Console.ReadLine();

                        if (CompanyDict[cName.ToUpper()][5] == 0)
                            GetDailyWage(cName.ToUpper());

                        Console.WriteLine("Today's Wage : ${0}", CompanyDict[cName.ToUpper()][5]);

                        Console.WriteLine("\n Press Enter to continue .."); Console.ReadLine(); UserInteractions();
                        break;
                    }
                case "4":
                    {
                        Console.Write("\n >>> Enter Company Name : "); string cName = Console.ReadLine();

                        if (CompanyDict[cName.ToUpper()][6] == 0)
                            GetMonthlyWage(cName.ToUpper());

                        Console.WriteLine("Monthly Wage : ${0}", CompanyDict[cName.ToUpper()][6]);

                        Console.WriteLine("\n Press Enter to continue .."); Console.ReadLine(); UserInteractions();
                        break;
                    }
                case "5":
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine(" TRY AGAIN !!");
                        UserInteractions();
                        break;
                    }
            }
        }
    }
}
