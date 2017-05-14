using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2_lab_5_7
{
    class Date
    {
        public int Year { get; set; } = 1976;
        public int Month { get; set; } = 1;
        public int Day { get; set; } = 1;

        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }
      
    }
}
