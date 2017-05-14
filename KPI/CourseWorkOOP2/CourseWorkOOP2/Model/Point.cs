using System;

namespace CourseWorkOOP2
{
    [Serializable]
    //Для серіалізації об'єкта похідного класу
    class Point
    {
        protected double x;
        protected double y;

        //Конструктор за замовчуванням
        public Point() : this(0.0, 0.0){}

        //Провідний конструктор
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        //Властивості
        public double X
        {
            get
            {
                return x;
            }

            set
            {
                if (value >= 0.0 && value < 700)
                {
                    x = value;
                }
                else
                {
                    x = 350.0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Значення х не входить у допустимi межi[0;700]. x = 350");
                    Console.ResetColor();
                }
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                if (value >= 0.0 && value < 500)
                {
                    y = value;
                }
                else
                {
                    y = 250.0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Значення y не входить у допустимi межi[0;500]. y = 250");
                    Console.ResetColor();
                }
            }
        }

    }
}
