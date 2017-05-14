using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab2_4
{
    internal class CardAccountAdvanced : CardAccount
    {
        static Date firstDateOfEnrollment;

        static CardAccountAdvanced() {
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("Статический конструктор производного класса CardAccountAdvanced");
            Console.ForegroundColor = ConsoleColor.Gray;
            firstDateOfEnrollment = new Date();
        }
        public CardAccountAdvanced() : base()
        {
            Console.ForegroundColor = ConsoleColor.White;
            //System.Console.WriteLine("Конструктор по умолчанию производного класса CardAccountAdvanced");
            Console.ForegroundColor = ConsoleColor.Gray;
            FirstDateOfEnrollment = new Date();
        }
        public CardAccountAdvanced(Date date) : base()
        {
            //System.Console.WriteLine("Конструктор с одним параметром производного класса CardAccountAdvanced");
            FirstDateOfEnrollment = date;
        }
        public CardAccountAdvanced(String surname, String name, Date dateOfBirth, Date dateOfEnrollment,
                           Education education, bool desireToServe) : base(surname, name, dateOfBirth, dateOfEnrollment,
                           education, desireToServe)
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            //System.Console.WriteLine("Конструктор инициализации производного класса CardAccountAdvanced");
            Console.ForegroundColor = ConsoleColor.Gray;
           DateOfEnrollment = dateOfEnrollment;
            FirstDateOfEnrollment = dateOfEnrollment;
        }
        public static Date FirstDateOfEnrollment
        {
            get
            {
                return firstDateOfEnrollment;
            }

            set
            {                   
                    int dayNew = value.Day;
                    int monthNew = value.Month;
                    int yearNew = value.Year;

                    int day = firstDateOfEnrollment.Day;
                    int month = firstDateOfEnrollment.Month;
                    int year = firstDateOfEnrollment.Year;



                    if (isNeedToReplaceDate(day, month, year, dayNew, monthNew, yearNew))
                    {
                        firstDateOfEnrollment = value;
                    }  
              
            }
        }

        private static bool isNeedToReplaceDate(int day, int month, int year, int dayNew, int monthNew, int yearNew)
        {
            if (year > yearNew)//2017 2016
            {
                return true;
            }
            else if (year < yearNew)//2016 2017
            {
                return false;
            }
            else //2017 2017
            {
                if (month > monthNew) // 12 11
                {
                    return true;
                }
                else if (month < monthNew) // 11 12
                {
                    return false;
                }
                else // 11 11
                {
                    if (day > dayNew)
                        return true;
                    else return false; 
                }

            }
        }

        //lab4

        public static CardAccountAdvanced operator+ (CardAccountAdvanced card, String secondSurname)
        {
            card.Surname = card.Surname + "-" + secondSurname;
            return card;
        }
        
        public static bool operator== (CardAccountAdvanced first, CardAccountAdvanced second)
        {
            return first.Surname == second.Surname && first.Name == second.Name && first.DateOfBirth == second.DateOfBirth &&
                first.DateOfEnrollment == second.DateOfEnrollment && first.getEducation() == second.getEducation() &&
                first.getDesireToServe() == second.getDesireToServe();
        }

        public static bool operator !=(CardAccountAdvanced first, CardAccountAdvanced second)
        {
            return first.Surname != second.Surname || first.Name != second.Name || (first.DateOfBirth != second.DateOfBirth) ||
               (first.DateOfEnrollment != second.DateOfEnrollment) || first.getEducation() != second.getEducation() ||
               first.getDesireToServe() != second.getDesireToServe();
        }

        public static bool operator! (CardAccountAdvanced obj)
        {
            return !(obj.getDesireToServe());
        }

        public static explicit operator String(CardAccountAdvanced obj)
        {
            return obj.Surname + " " + obj.Name;
        }
        public static explicit operator bool(CardAccountAdvanced obj)
        {
            return obj.getDesireToServe();
        }

        public override bool Equals(Object obj)
        {

            if (GetType() == obj.GetType())
            {
                CardAccountAdvanced card = (CardAccountAdvanced)obj;
                return this.Surname == card.Surname && this.Name == card.Name && this.DateOfBirth == card.DateOfBirth
                    && this.DateOfEnrollment == card.DateOfEnrollment && this.getEducation() == card.getEducation()
                    && this.getDesireToServe() == card.getDesireToServe();
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            int result = Surname.GetHashCode();
            result = 13 * result + Name.GetHashCode();
            result = 23 * result + DateOfBirth.GetHashCode();
            result = 17 * result + DateOfEnrollment.GetHashCode();
            result = 31 * result + getEducation().GetHashCode();
            result = 23 * result + getDesireToServe().GetHashCode();
           
            
            return result;
        }

        public static new void topForDisplay()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            ///Шапка таблицы
            ///
            Console.Write('\n');
            Console.Write('+');
            for (int i = 0; i < 92; i++) { Console.Write('-'); }
            Console.Write('+' + "\n");
            Console.Write('|' + "     Фамилия   " + '|' + "   Имя   " + '|' + "Год рожд. " + '|' + "Дата зачис" + '|'
                + "Образование " + '|' + "Желание служить" + '|' + "Первая дата зач" + '|' + "\n");

            Console.Write('|'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 9; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 10; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 10; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 12; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('|' + "\n");
        }
        public new void displayFields()
        {

            Console.Write('|' + "{0,15}", Surname);
            Console.Write('|' + "{0,9}", Name);
            Console.Write('|' + "{0,2:##}.{1,2:##}.{2,4:####}", DateOfBirth.Day, DateOfBirth.Month, DateOfBirth.Year);
            Console.Write('|' + "{0,2:##}.{1,2:##}.{2,4:####}", DateOfEnrollment.Day, DateOfEnrollment.Month, DateOfEnrollment.Year);

            Console.Write('|' + "{0,12}", getEducation());
            Console.Write('|' + "{0,15}", getDesireToServe());
            Console.Write('|' + "  {0,2:##}.{1,2:##}.{2,4:####}   ", FirstDateOfEnrollment.Day, FirstDateOfEnrollment.Month,
                FirstDateOfEnrollment.Year);
            Console.Write('|' + "\n");

            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 9; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 10; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 10; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 12; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+' + "\n");
            // Console.Write('\n');
        }
    }
}
