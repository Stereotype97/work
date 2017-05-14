using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2_lab_5_7
{
    class Student : Person
    {
        StudyGroup studyGroup;
        readonly Date currentDate = new Date(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        int age;

        internal Date CurrentDate
        {
            get
            {
                return currentDate;
            }
        }
        internal StudyGroup StudyGroup
        {
            get
            {
                return studyGroup;
            }

            set
            {
                studyGroup = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public Student(String surname, String name, Date date, String sex, StudyGroup studyGroup) : base(surname, name, date, sex)
        {
            StudyGroup = studyGroup;
            Age = confirmAge();            
        }

        int confirmAge()
        {
            int result = CurrentDate.Year - Birthday.Year - 1;
            if (CurrentDate.Month > Birthday.Month)
            {
                result++;
            }
            else if (CurrentDate.Month == Birthday.Month && CurrentDate.Day >= Birthday.Day)
            {
                result++;
            }

            return result;
        }

        public static void topForDisplay()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            ///Шапка таблицы
            ///
           
            Console.Write('+');
            for (int i = 0; i < 74
                ; i++) { Console.Write('-'); }
            Console.Write('+' + "\n");
            Console.Write('|' + "     Фамилия   " + '|' + "   Имя   " + '|' + "Год рожд. " + '|' + "  Шифр "
                + '|' + "Факул" + '|' + " Специальность " + '|' + "Возраст" + '|' + "\n");

            Console.Write('|'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 9; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 10; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 7; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 5; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 7; i++) { Console.Write('-'); }
            Console.Write('|' + "\n");
        }
        public void displayFields()
        {

            Console.Write('|' + "{0,15}", Surname);
            Console.Write('|' + "{0,9}", Name);
            Console.Write('|' + "{0,2:##}.{1,2:##}.{2,4:####}", Birthday.Day, Birthday.Month, Birthday.Year);
            Console.Write('|' + "{0,7}", StudyGroup.GroupCipher);

            Console.Write('|' + "{0,5}", StudyGroup.Faculty);
            Console.Write('|' + "{0,15}", StudyGroup.Speciality);
            Console.Write('|' + "{0,7}", Age);
            Console.Write('|' + "\n");

            Console.Write('|'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 9; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 10; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 7; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 5; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 7; i++) { Console.Write('-'); }
            Console.Write('+' + "\n");
            // Console.Write('\n');
        }

        public void display()
        {
            topForDisplay();
            displayFields();
        }
    }
}
