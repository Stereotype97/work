using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace CourseWorkOOP2
{
    class OutputMethod
    {       
        /**
         * Усі функції описані ключовим словом static для того, щоб викликати їх без створення єкземпляру класу
         */ 
        //Звичайний вивід на консоль
        public static void simplyOutputOnScreen(String message)
        {
            Console.Write(message);
        }
        //Вивід повідомлення про успіх виконання зеленим кольором на консоль
        public static void successOutputOnScreen(String message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
        }
        //Вивід повідомлення про помилку червоним кольором на консоль
        public static void errorOutputOnScreen(String message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
        }
        //Запис у бінарний файл, серіалізація об'єктів
        public static void serializationOutputInBinaryFile(List<CircleInscribedInSquareWithLegend> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            //Область видимості файлового потоку, дозволяє не закривати файл
            using (FileStream file = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                @"\objects.dat", FileMode.OpenOrCreate))//Шлях - Мої документи\Файл
            {
                formatter.Serialize(file, list);
            }
        }
        //Запис у текстовий файл списку об'єктів, що передані у функцію, у вигляді таблички
        public static void outputInTextFile(List<CircleInscribedInSquareWithLegend> list)
        {
            using (StreamWriter file = new StreamWriter(
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                            @"\objects.txt", true))//true - дозаписує у файл
            {
               
                file.Write('+');
                for (int j = 0; j < 75; j++) { file.Write('-'); }
                file.WriteLine('+');
                file.WriteLine('|' + "  Xц  " + '|' + "  Уц  " + '|' + "Радiус" + '|' + "Довжина нап."
                    + '|' + "         Текст напису         " + '|' + "Кут нахилу" + '|');
                
                file.Write('|'); for (int j = 0; j < 6; j++) { file.Write('-'); }
                file.Write('+'); for (int j = 0; j < 6; j++) { file.Write('-'); }
                file.Write('+'); for (int j = 0; j < 6; j++) { file.Write('-'); }
                file.Write('+'); for (int j = 0; j < 12; j++) { file.Write('-'); }
                file.Write('+'); for (int j = 0; j < 30; j++) { file.Write('-'); }
                file.Write('+'); for (int j = 0; j < 10; j++) { file.Write('-'); }
                file.WriteLine('|');

                int i = 0;
                while (i < list.Count)
                {
                    file.Write('|' + "{0,6}", list[i].Circle.X);
                    file.Write('|' + "{0,6}", list[i].Circle.Y);
                    file.Write('|' + "{0,6}", list[i].Circle.Radius);
                    file.Write('|' + "{0,12}", list[i].Legend.Legend.Length);
                    file.Write('|' + "{0,30}", list[i].Legend.Legend.Text);
                    file.Write('|' + "{0,10}", list[i].Legend.TiltAngle);
                    file.WriteLine('|');
                    i++;
                }
                file.Write('+'); for (int j = 0; j < 6; j++) { file.Write('-'); }
                file.Write('+'); for (int j = 0; j < 6; j++) { file.Write('-'); }
                file.Write('+'); for (int j = 0; j < 6; j++) { file.Write('-'); }
                file.Write('+'); for (int j = 0; j < 12; j++) { file.Write('-'); }
                file.Write('+'); for (int j = 0; j < 30; j++) { file.Write('-'); }
                file.Write('+'); for (int j = 0; j < 10; j++) { file.Write('-'); }
                file.WriteLine('+');
            }
        }
        //Вивід на консоль списку об'єктів, що передані у функцію, у вигляді таблички
        public static void outputOnScreen(List<CircleInscribedInSquareWithLegend> list)
        {
            Console.Write('+');
            for (int j = 0; j < 75; j++) { Console.Write('-'); }
            Console.Write('+' + "\n");
            Console.Write('|' + "  Xц  " + '|' + "  Уц  " + '|' + "Радiус" + '|' + "Довжина нап."
                + '|' + "         Текст напису         " + '|' + "Кут нахилу" + '|' + "\n");

            Console.Write('|'); for (int j = 0; j < 6; j++) { Console.Write('-'); }
            Console.Write('+'); for (int j = 0; j < 6; j++) { Console.Write('-'); }
            Console.Write('+'); for (int j = 0; j < 6; j++) { Console.Write('-'); }
            Console.Write('+'); for (int j = 0; j < 12; j++) { Console.Write('-'); }
            Console.Write('+'); for (int j = 0; j < 30; j++) { Console.Write('-'); }
            Console.Write('+'); for (int j = 0; j < 10; j++) { Console.Write('-'); }
            Console.Write('|' + "\n");

            int i = 0;
            while (i < list.Count)
            {
                Console.Write('|' + "{0,6}", list[i].Circle.X);
                Console.Write('|' + "{0,6}", list[i].Circle.Y);
                Console.Write('|' + "{0,6}", list[i].Circle.Radius);
                Console.Write('|' + "{0,12}", list[i].Legend.Legend.Length);
                String text;
                if (list[i].Legend.Legend.Text.Length > 30)
                {
                    text = list[i].Legend.Legend.Text.Substring(0, 30);
                }
                else text = list[i].Legend.Legend.Text;
                Console.Write('|' + "{0,30}", text);
                Console.Write('|' + "{0,10}", list[i].Legend.TiltAngle);
                Console.Write('|' + "\n");
                i++;
            }
            Console.Write('+'); for (int j = 0; j < 6; j++) { Console.Write('-'); }
            Console.Write('+'); for (int j = 0; j < 6; j++) { Console.Write('-'); }
            Console.Write('+'); for (int j = 0; j < 6; j++) { Console.Write('-'); }
            Console.Write('+'); for (int j = 0; j < 12; j++) { Console.Write('-'); }
            Console.Write('+'); for (int j = 0; j < 30; j++) { Console.Write('-'); }
            Console.Write('+'); for (int j = 0; j < 10; j++) { Console.Write('-'); }
            Console.Write('+' + "\n");

        }
    }
}
