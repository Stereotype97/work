using System;
using System.Text.RegularExpressions;
namespace OOP_lab2_4
{
    public enum Education { LowerSecondary, UpperSecondary, IncompleteHigher, Higher};
    internal class CardAccount
    {
        private String surname;
        private String name;
        private Date dateOfBirth;
        private Date dateOfEnrollment;
        private Education education;
        private bool desireToServe;

       

        /**Contructors*/
        public CardAccount(String surname, String name, Date dateOfBirth, Date dateOfEnrollment,
                           Education education, bool desireToServe)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //Console.WriteLine("Конструктор инициализации базового класса CardAccount");
            Console.ForegroundColor = ConsoleColor.Gray;
            this.surname = surname;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.dateOfEnrollment = dateOfEnrollment;
            this.education = education;
            this.desireToServe = desireToServe;
        }

        public CardAccount() : this("Не указана", "  -//-  ", new Date(), new Date(), Education.Higher, false) {

            //System.Console.WriteLine("Конструктор по умолчанию базового класса CardAccount");
        }
        public CardAccount(String surname, String name, bool desireToServe) : 
            this(surname, name, new Date(), new Date(), Education.Higher, desireToServe) { } 

        public String Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
            }
        public String Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
      
        public Date DateOfBirth {
            get
            {
                return dateOfBirth;
            }
            private set { } }

        internal Date DateOfEnrollment
        {
            get
            {
                return dateOfEnrollment;
            }

            set
            {
                dateOfEnrollment = value;
            }
        }

        public String getEducation() {
            String result = "";
            switch (education)
            {
                case Education.LowerSecondary: result = "Неп.среднее";
                    break;
                case Education.UpperSecondary: result = "Пол.среднее";
                    break;
                case Education.IncompleteHigher: result = "Неп.высшее";
                    break;
                case Education.Higher: result = "Пол.высшее";
                    break;
            }
            return result;
        }
        public void setEducation(int number)
        {
            switch (number)
            {
                case 0: education = Education.LowerSecondary;
                    return;
                case 1: education = Education.UpperSecondary;
                    return;
                case 2: education = Education.IncompleteHigher;
                    return;
            }
            education = Education.Higher;
        }
        public bool getDesireToServe()
        {
            return desireToServe;
        }
        public void setDesireToServe(bool desireToServe)
        {
            this.desireToServe = desireToServe;
        }

        public void showStaticField()
        {
            Date localDate = CardAccountAdvanced.FirstDateOfEnrollment;
            System.Console.WriteLine("\nСамая ранняя дата зачисления - " + localDate.Day + '.' + localDate.Month +
                '.' + localDate.Year);
        }

        public static void topForDisplay()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            ///Шапка таблицы
            ///
            Console.Write('\n');
            Console.Write('+');
            for (int i = 0; i < 76; i++) { Console.Write('-'); }
            Console.Write('+' + "\n");
            Console.Write('|' + "     Фамилия   " + '|' + "   Имя   " + '|' + "Год рожд. " + '|' + "Дата зачис" + '|' + "Образование " + '|' + "Желание служить" + '|' + "\n");

            Console.Write('|'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 9; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 10; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 10; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 12; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('|' + "\n");
        }
        public void displayFields()
        {
           
            Console.Write('|' + "{0,15}", Surname);
            Console.Write( '|' + "{0,9}", name);
            Console.Write( '|' + "{0,2:##}.{1,2:##}.{2,4:####}", dateOfBirth.Day, dateOfBirth.Month, dateOfBirth.Year);
            Console.Write( '|' + "{0,2:##}.{1,2:##}.{2,4:####}", DateOfEnrollment.Day, DateOfEnrollment.Month, DateOfEnrollment.Year);

            Console.Write( '|' + "{0,12}", getEducation());
            Console.Write( '|' + "{0,15}", desireToServe);
            Console.Write( '|' + "\n");

            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 9; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 10; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 10; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 12; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
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
