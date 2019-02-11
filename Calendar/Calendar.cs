using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Calendar
{
    public class Calendar
    {
        private const string Space = "  ";

        private readonly DateTime[] _holidays =
        {
            new DateTime(1, 1, 1),
            new DateTime(1, 1, 2),
            new DateTime(1, 1, 3),
            new DateTime(1, 1, 4),
            new DateTime(1, 1, 5),
            new DateTime(1, 1, 6),
            new DateTime(1, 1, 7),
            new DateTime(1, 1, 8),
            new DateTime(1, 1, 23),
            new DateTime(1, 2, 14),
            new DateTime(1, 2, 23),
            new DateTime(1, 3, 8),
            new DateTime(1, 5, 1),
            new DateTime(1, 5, 9),
            new DateTime(1, 6, 12),
            new DateTime(1, 7, 7),
            new DateTime(1, 9, 1),
            new DateTime(1, 10, 5),
            new DateTime(1, 10, 20),
            new DateTime(1, 11, 3),
            new DateTime(1, 11, 4)
        };

        public void Start()
        {
            Console.WriteLine("Please, enter your date:");
            var dateString = Console.ReadLine();
            DateTime dateValue;
            if (!DateTime.TryParse(dateString, out dateValue))
            {
                Console.WriteLine("Sorry, format of your date is wrong :(");
                return;
            }

            var ci = new CultureInfo("ru-RU");
            var dtfi = ci.DateTimeFormat;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < dtfi.ShortestDayNames.Length; i++)
            {
                var idx = i % 7 + (int) DayOfWeek.Monday;
                if (idx > 6)
                {
                    idx -= 7;
                }

                Console.Write("{0}{1}", dtfi.ShortestDayNames[idx], Space);
            }

            Console.WriteLine();

            var weekendCount = 0;
            for (int i = 1; i <= DateTime.DaysInMonth(dateValue.Year, dateValue.Month); i++)
            {
                var curDate = new DateTime(dateValue.Year, dateValue.Month, i);
                if (curDate.DayOfWeek != DayOfWeek.Saturday && curDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    weekendCount++;
                }

                Console.ForegroundColor = ColorDate(dateValue, curDate);
                Console.Write("{0}{1}", SpaceForDayInMonth(curDate, DayOfWeek.Monday), curDate.Day);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nWorks day count = {0}", weekendCount);
        }

        private int DayOfWeekStartFromCurrentDay(int value, DayOfWeek firstDayOfWeek)
        {
            var idx = 7 + value - (int) firstDayOfWeek;
            if (idx > 6)
            {
                idx -= 7;
            }

            return idx;
        }

        private string SpaceForDayInMonth(DateTime date, DayOfWeek firstDayOfWeek)
        {
            var spaces = new StringBuilder();
            if (date.Day == 1)
            {
                var number = DayOfWeekStartFromCurrentDay((int) date.DayOfWeek, firstDayOfWeek) * 2;
                for (var i = 0; i < number; i++)
                {
                    spaces.Append(Space);
                }
            }
            else if (date.DayOfWeek == DayOfWeek.Monday)
            {
                spaces.Append("\n");
            }
            else
            {
                spaces.Append(Space);
                if (date.Day < 11)
                {
                    spaces.Append(" ");
                }
            }

            return spaces.ToString();
        }

        private ConsoleColor ColorDate(DateTime userDate, DateTime curDate)
        {
            ConsoleColor curColor;
            if (curDate == userDate)
            {
                curColor = ConsoleColor.DarkGreen;
            }
            else if (curDate.DayOfWeek == DayOfWeek.Saturday || curDate.DayOfWeek == DayOfWeek.Sunday)
            {
                curColor = ConsoleColor.DarkRed;
            }
            else if (_holidays.Any(holiday => holiday.Day == curDate.Day && holiday.Month == curDate.Month))
            {
                curColor = ConsoleColor.DarkRed;
            }
            else
            {
                curColor = ConsoleColor.White;
            }

            return curColor;
        }
    }
}