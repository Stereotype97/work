using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CourseWorkOOP2
{
    class Utilities
    {
        /**
         * Усі функції описані ключовим словом static для того, щоб викликати їх без створення єкземпляру класу
         */
         //
        //Функція зчитування з консолі цілого числа(з використанням виключень)
        public static int getIntFromConsole()
        {
            int value;
            try
            {
                String str;
                while ((str = Console.ReadLine()) == "") ;
                value = Int32.Parse(str);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка! Введiть цiле число");
                Console.ResetColor();
                value = getIntFromConsole();//Якщо помилка, викликати функцію знову
            }

            return value;
        }

        //Функція зчитування з консолі числа з плавающою (з використанням виключень)
        public static double getDoubleFromConsole()
        {
            double value;
            try
            {
                String str;
                while ((str = Console.ReadLine()) == "") ;
                value = Double.Parse(str);
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка! Введiть дробове число(цiлу i дробову частину повинна вiддiляти кома)");
                value = getDoubleFromConsole();//Якщо помилка, викликати функцію знову
            }

            return value;
        }
        //Зчитування списку об'єктів з бінарного файлу, десеріалізація
        public static List<CircleInscribedInSquareWithLegend> getListObjectsFromBinaryFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<CircleInscribedInSquareWithLegend> list;
            using (FileStream file = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + 
                @"\objects.dat", FileMode.Open))
            {
                list = (List<CircleInscribedInSquareWithLegend> )formatter.Deserialize(file);
            }
           

            return list;
        }
        //Зчитування списку об'єктів з текстового файлу порядково
        public static List<CircleInscribedInSquareWithLegend> getListObjectsFromTextFile()
        {
            using (StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + 
                @"\InputValues.txt"))
            {
                //Для застосування перевантаженного бінарного оператора +
                FiguresOnScreen figures = new FiguresOnScreen();
                while (!sr.EndOfStream)//Поки не кінець файлу
                {
                    String str = sr.ReadLine();//Читаємо усю строку
                    String[] parsingStr = str.Split();//Відділяємо значення один від одного
                    // і приводимо їх до відповідних типів
                    Double.TryParse(parsingStr[0], out double x);
                    Double.TryParse(parsingStr[1], out double y);
                    Double.TryParse(parsingStr[2], out double radius);
                    float.TryParse(parsingStr[3], out float length);
                    Int32.TryParse(parsingStr[4], out int tilt);
                    //Текст напису розбито на слова, конкатенуємо їх в одну строку
                    String text = "";
                    for(int i = 5; i < parsingStr.Length; i++)
                    {
                        text += parsingStr[i] + " ";
                    }
                    text = text.TrimEnd(' ');//Видаляє пробіл з кінця

                    Circle local = new Circle(radius, x, y);

                    //Перевантажений бінарний оператор +, додаємо до списку новий об'єкт
                    figures = figures + new CircleInscribedInSquareWithLegend(local,
                        new LegendOnCircle(local, new Legend(length, text), tilt));
                }
                return figures.List;
            }
        }

        //Статистичні функції
        //Середнє геометричне довжини і площі кіл
        public static void averageGeometric(List<CircleInscribedInSquareWithLegend> list)
        {
            double accumulatingPerimeter = 1.0;
            double accumulatingArea = 1.0;
            foreach (CircleInscribedInSquareWithLegend obj in list)
            {
                accumulatingPerimeter *= obj.Circle.Perimetr;
                accumulatingArea *= obj.Circle.Area;
            }

            Console.WriteLine("Середнє геометричне довжини кiл: " + Math.Pow(accumulatingPerimeter, 1.0 / list.Count));
            Console.WriteLine("Середнє геометричне площi кiл: " + Math.Pow(accumulatingArea, 1.0 / list.Count));
        }

        //Середнє гармонійне довжини і площі кіл
        public static void averageGarmonic(List<CircleInscribedInSquareWithLegend> list)
        {
            
            double accumulatingPerimeter = 0.0;
            double accumulatingArea = 0.0;
            foreach (CircleInscribedInSquareWithLegend obj in list)
            {
                accumulatingPerimeter += Math.Pow(obj.Circle.Perimetr, -1);
                accumulatingArea += Math.Pow(obj.Circle.Area, -1);
            }
            Console.WriteLine("Середнє гармонiйне довжини кiл: " + list.Count / accumulatingPerimeter);
            Console.WriteLine("Середнє гармонiйне площi кiл: " + list.Count / accumulatingArea);
        }

        //Функція пошуку за числовим полем з використанням індексатора
        public static List<CircleInscribedInSquareWithLegend> findDoubleIn(FiguresOnScreen figures,
            double value)
        {
            List<CircleInscribedInSquareWithLegend> result = new List<CircleInscribedInSquareWithLegend>();
            for(int i = 0; i < figures.List.Count; i++)
            {
                if (figures[i].Circle.Radius == value)
                {
                    result.Add(figures[i]);
                }
            }
            return result;
        }
        //Функція пошуку за текстовим полем з використанням індексатора
        public static List<CircleInscribedInSquareWithLegend> findSubstringIn(FiguresOnScreen figures, String value)
        {
            List<CircleInscribedInSquareWithLegend> result = new List<CircleInscribedInSquareWithLegend>();
            for (int i = 0; i < figures.List.Count; i++)
            {
                if (figures[i].Legend.Legend.Text.ToLower().Contains(value.ToLower()))
                {
                    result.Add(figures[i]);
                }
            }
            return result;
        }
    }
}
