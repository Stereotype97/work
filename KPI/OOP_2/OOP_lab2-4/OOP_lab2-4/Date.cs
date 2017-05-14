using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2_4
{
    class Date
    {
        int day;
        int month;
        int year;

        public Date()
        {
            day = 29;
            month = 3;
            year = 2017;
        }
        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public int Day {
            get
            {
                return day;
            }
            set
            {
                if (value > 0 && value < 32)
                {
                    day = value;
                }
                else
                {
                    day = 1;
                }
            }
            }
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if (value > 0 && value < 13)
                {
                    month = value;
                }
                else
                {
                    month = 1;         
                }
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value > 0 && value < 32)
                {
                    year = value;
                }
                else
                {
                    year = 2017;
                }
            }
        }

        public static bool operator ==(Date first, Date second)
        {

            return first.day == second.day && first.month == second.month && first.year == second.year;
        }

        public static bool operator!= (Date first, Date second)
        {
          
            return first.day != second.day || first.month != second.month || first.year != second.year;
        }

        public override bool Equals(Object obj)
        {
            if (!(this is Date)) return false;
            
            if (GetType() == obj.GetType())
            {
                Date date = (Date)obj;
                return this.Day == date.Day && this.Month == date.Month && this.Month == date.Month;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            int result = day;
            result = 13 * result + month;
            result = 23 * result + year;
            return result;
        }
    }
}
