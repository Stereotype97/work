using System;

namespace lab1
{
    internal class Aproximation
    {
        private double[] arrayTeilor, coefTeilor, arrayFunc, arrayArg;
        private int size, countOfTeilorMembers;
        private double a, b, h, accuracy;

        public Aproximation() //Конструктор по умолчанию
        {
            a = 0;
            b = 0;
            h = 0;
            size = 1;
            countOfTeilorMembers = 0;

            arrayTeilor = new double[] { 0.0 };
            coefTeilor = new double[] { 0.0 };
            arrayArg = new double[] { 0.0 };
            arrayFunc = new double[] { 0.0 };
           
        }

        public Aproximation(double a, double b, double h, int countOfTeilorMembers)  //Конструктор инициализации
        {
            this.h = h;
            this.a = a;
            this.b = b;
            size = (int)((Math.Abs(b - a)) / h) + 1;

            if (countOfTeilorMembers > 30)
                this.countOfTeilorMembers = 30;
            else
                this.countOfTeilorMembers = countOfTeilorMembers;

            arrayTeilor = new double[size];
            coefTeilor = new double[this.countOfTeilorMembers];
            arrayArg = new double[size];
            arrayFunc = new double[size];
            int k = 0;

            //Расчет аргументов и точных значений функций
            for (double i = a; i <= b; i += h, k++)
            {
                arrayFunc[k] = Math.Pow((1 + i), -1);
                arrayArg[k] = Math.Round(i, 10);
            }

            //Расчет знаков при членах ряда Тэйлора
            for (int i = 0; i < this.countOfTeilorMembers; i++)
            {
                if(i % 2 == 0) coefTeilor[i] = 1;
                else coefTeilor[i] = -1;
            }

            //Расчет приближенного значения функции по ряду Тэйлора
            for (int i = 0; i < size; i++)
            {
                arrayTeilor[i] = 0;
                for (int j = 0; j < this.countOfTeilorMembers; j++)
                    arrayTeilor[i] += coefTeilor[j] * Math.Pow(arrayArg[i], j);
            }


            /* 
            * Расчет абсол. и относ. погрешности
            * Итерации будут выполняться пока относительная погрешность аппроксимации 
            * не будет меньше указанного в главной программе значения EPS
            */
            accuracy = 0;
            for (int i = 0; i < size; i++)
            {
                if (arrayFunc[i] != 0)
                    accuracy += (Math.Abs(arrayTeilor[i] - arrayFunc[i]) / arrayFunc[i]) * 100;
                else accuracy += 100;
            }
            accuracy /= size;
        }

        public double getEps()
        {
            return accuracy;
        }

        public void Normalize(int upperBound) //Нормализация полей класса: массива значений точной и приближенной ф-й
        {
            double max = arrayTeilor[0], min = arrayTeilor[0];
            for (int i = 0; i < size; i++)
            {
                if (max < arrayTeilor[i])
                    max = arrayTeilor[i];
                if (min > arrayTeilor[i])
                    min = arrayTeilor[i];
            }

            for (int i = 0; i < size; i++)
            {
                if (max < arrayFunc[i])
                    max = arrayFunc[i];
                if (min > arrayFunc[i])
                    min = arrayFunc[i];
            }
            for (int i = 0; i < size; i++)
            {
                arrayTeilor[i] = ((arrayTeilor[i] - min) / Math.Abs(min - max)) * upperBound;
            }
            for (int i = 0; i < size; i++)
            {
                arrayFunc[i] = ((arrayFunc[i] - min) / Math.Abs(min - max)) * upperBound;
            }
        }

        public void showTable() //Вывод на консоль таблицы зависимости среднего значения абсолютных погрешностей
                                //в определенном диапазоне аппроксимации от размера диапазона
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            ///Шапка таблицы
            for (int i = 0; i < 64; i++) { Console.Write('-'); }
            Console.Write('-' + "\n");
            Console.Write('|' + "       x       " + '|' + " Точная функция" + '|' + "  Ряд Тэйлора  " + '|' + "Абс.погрешность" + '|' + "\n");

            Console.Write('|'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('+'); for (int i = 0; i < 15; i++) { Console.Write('-'); }
            Console.Write('|' + "\n");

            for (int j = 0; j < size; j++) //Итерационный вывод полей таблицы
            {
                Console.Write('|' + "{0,12}", Math.Round(arrayArg[j], 6));
                Console.Write("   " + '|' + "{0,12}", Math.Round(arrayFunc[j], 6));
                Console.Write("   " + '|' + "{0,12}", Math.Round(arrayTeilor[j], 6));
                Console.Write("   " + '|' + "{0,12}", Math.Round(Math.Abs(arrayTeilor[j] - arrayFunc[j]), 6));
                Console.Write("   " + '|' + "\n");
                if (j != (size - 1))
                {
                    Console.Write('|');
                    for (int i = 0; i < 63; i++) {
                        Console.Write('-');
                    }                 
                    Console.Write('|' + "\n");
                }
                else
                {
                    for (int i = 0; i < 64; i++)
                    {
                        Console.Write('-');
                    }
                    Console.Write('-' + "\n");
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Средняя относительная погрешность = " + Math.Round(accuracy, 3) + "%, " + 
                "где количество коэфициентов в ряду Тэйлора = " + countOfTeilorMembers);
        }

        public void showGraph() //Вывод на консоль линейных гистограм нормированных значений точной и приближенной функций
        {
            int upperBound = 100;
            Normalize(upperBound);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Точная функция f(x)");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Аппроксимирующий ряд Тэйлора");
            
            for (int i = 0; i < size; i++)
            {
                
                    Console.BackgroundColor = ConsoleColor.Blue;
                    
                    for (double j = 0; j <= arrayFunc[i]; j++)
                {
                        Console.Write(' ');
                }

                Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("\n");

                    Console.BackgroundColor = ConsoleColor.Gray;
                   
                    for (double j = 0; j <= arrayTeilor[i]; j++)
                {
                      Console.Write(' ');
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\n");
                
              
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
   
        }
  
    }
}