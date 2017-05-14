using CourseWorkOOP2.Interfaces;
using CourseWorkOOP2.Observers;
using System;
using System.Collections.Generic;
using System.IO;

namespace CourseWorkOOP2
{
    public delegate void ShowOnScreen(String message); //Делегат для виводу повідомлень на екран

    //Делегат для статистичних функцій і виводу їх значень на екран
    delegate void StatisticDelegate(List<CircleInscribedInSquareWithLegend> list);

    class Menu
    {
        FiguresOnScreen figures = new FiguresOnScreen();//Об'єкт похідного класу
        //Визначення делегатів відповідних типів
        public ShowOnScreen delShowOnScreen;
        StatisticDelegate statisticDelegate;
        
        //Статична функція виводу меню на консоль
        public static void showMenu()
        {
            Console.WriteLine("Головне меню\n");
            Console.WriteLine("Для введення даних, натиснiть 1.");
            Console.WriteLine("Для виведення даних у виглядi таблички, натиснiть 2.");
            Console.WriteLine("Для запису об'єктiв на диск у текстовий файл, натиснiть 3.");
            Console.WriteLine("Для запису об'єктiв на диск у бiнарний файл, натиснiть 4.");
            Console.WriteLine("Для зчитування даних з текстового файлу, натиснiть 5.");
            Console.WriteLine("Для зчитування даних з бiнарного файлу, натиснiть 6.");
            Console.WriteLine("Для пошуку даних в масивi об'єктiв за текстовим чи числовим полем, натиснiть 7.");
            Console.WriteLine("Для розрахунку статистичної функцiї, щоб охарактеризувати данi, натиснiть 8");
            Console.WriteLine("Для додання об'єкту до поточного списку, натиснiть 9");
            Console.WriteLine("Для того, щоб вийти з програми, натиснiть 0.\n");
        }
        //Головний процес, який викликатиметься в Main()
        public void process()
        {
            //Додання спостерігачів
            figures.addObserver(new ConsoleObserver());
            figures.addObserver(new FileObserver());
            //Очищення лог-файлу
            StreamWriter logFile = new StreamWriter(
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                            @"\LogFile_Observer.txt", false);
            logFile.Close();

            int choice;
            do
            {
                delShowOnScreen = OutputMethod.simplyOutputOnScreen;//Передача в делегат методу, який треба викликати
                delShowOnScreen("Ваш вибiр: ");
                while ((!Int32.TryParse((Console.ReadLine()), out choice)) || (choice < 0 || choice > 9))
                {
                    delShowOnScreen = OutputMethod.errorOutputOnScreen;//Передача в делегат методу про вивід помилки
                    delShowOnScreen("Допускаються лише цифри вiд 0 до 9\n");
                }
                //Очищення консолі
                //Console.Clear();
                //showMenu();

                switch (choice)
                {
                    case 1:
                        {//Введення даних
                            inputData();
                            //Повідомлення спостерігачам, що кількість об'єктів змінено
                            figures.notifyObservers(figures.List.Count);
                            break;
                        }
                    case 2:
                        //Виведення даних у виглядi таблички на екран
                        if (figures.List.Count != 0)
                        {
                            OutputMethod.outputOnScreen(figures.List);
                        }
                        else
                        {
                            delShowOnScreen = OutputMethod.errorOutputOnScreen;
                            delShowOnScreen("\nДаних для виведення ще немає, натиснiть 1, щоб ввести данi.\n");
                        }
                        break;

                    case 3:
                        //Запис об'єктiв на диск у текстовий файл
                        //Очищення файлу
                        StreamWriter file = new StreamWriter(
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                            @"\objects.txt", false);
                        file.Close();

                        if (figures.List.Count != 0)
                        {
                            OutputMethod.outputInTextFile(figures.List);
                            delShowOnScreen = OutputMethod.successOutputOnScreen;
                            delShowOnScreen("До текстового файлу успiшно записано!\n");
                        }
                        else
                        {
                            delShowOnScreen = OutputMethod.errorOutputOnScreen;
                            delShowOnScreen("Немає даних для запису у текстовий файл!\n");
                        }
                        break;

                    case 4:
                        //Запис об'єктiв на диск у бiнарний файл
                        if (figures.List.Count != 0)
                        {
                            OutputMethod.serializationOutputInBinaryFile(figures.List);
                            delShowOnScreen = OutputMethod.successOutputOnScreen;
                            delShowOnScreen("До бiнарного файлу успiшно записано!\n");
                        }
                        else
                        {
                            delShowOnScreen = OutputMethod.errorOutputOnScreen;
                            delShowOnScreen("Немає даних для запису у бiнарний файл!\n");
                        }
                        
                        break;

                    case 5:
                        //Зчитування даних з текстового файлу
                        try
                        {
                            figures.List = Utilities.getListObjectsFromTextFile();
                            delShowOnScreen = OutputMethod.successOutputOnScreen;
                            delShowOnScreen("З текстового файлу успiшно зчитано об'єкти!\n");
                        }
                        catch (FileNotFoundException)
                        {
                            delShowOnScreen = OutputMethod.errorOutputOnScreen;
                            delShowOnScreen(@"Файлу за шляхом C:\Users\USER_NAME\Documents\InputValues.txt не iснує.\n");
                            delShowOnScreen("Створiть його, розмiстивши в кожному рядку через пробiл поля об'єкта\n" +
                                "Х У Радiус Довжину_напису Кут_нахилу Текст напису (до кiнця рядка)\n");
                        }
                        //Повідомлення спостерігачам, що кількість об'єктів змінено
                        figures.notifyObservers(figures.List.Count);
                        break;

                    case 6:
                        //Зчитування даних з бiнарного файлу
                        try
                        {
                            figures.List = Utilities.getListObjectsFromBinaryFile();
                            delShowOnScreen = OutputMethod.successOutputOnScreen;
                            delShowOnScreen("З бiнарного файлу успiшно зчитано об'єкти!\n");
                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            delShowOnScreen = OutputMethod.errorOutputOnScreen;
                            delShowOnScreen(@"Файлу за шляхом C:\Users\USER_NAME\Documents\objects.dat не iснує.\n");
                            delShowOnScreen("Створiть його за допомогою пункту 1 i 5\n");
                        }
                        //Повідомлення спостерігачам, що кількість об'єктів змінено
                        figures.notifyObservers(figures.List.Count);
                        break;

                    case 7:
                        //Пошук даних в масивi об'єктiв за текстовим чи числовим полем
                        if (figures.List.Count != 0)
                        {
                            Console.WriteLine("За яким полем бажаєте вести пошук у масивi об'єктiв?");
                            Console.WriteLine("1 - за числовим(радiус)");
                            Console.WriteLine("2 - за текстовим");
                            Console.Write("Поле: ");
                            int ch;
                            while ((ch = Utilities.getIntFromConsole()) < 1 || ch > 2)
                            {
                                delShowOnScreen = OutputMethod.errorOutputOnScreen;
                                delShowOnScreen("Тiльки 1 або 2\n");
                                delShowOnScreen = OutputMethod.simplyOutputOnScreen;
                            }
                            switch (ch)
                            {
                                case 1:
                                    {
                                        double value;
                                        delShowOnScreen("Введiть шуканий радiус: ");
                                        while ((value = Utilities.getDoubleFromConsole()) <= 0)
                                        {
                                            delShowOnScreen = OutputMethod.errorOutputOnScreen;
                                            delShowOnScreen("Радiус вписаного кола не може бути вiд'ємною величиною!\n");
                                            delShowOnScreen = OutputMethod.simplyOutputOnScreen;
                                        }

                                        List<CircleInscribedInSquareWithLegend> temp = Utilities.findDoubleIn(figures, value);
                                        if (temp.Count != 0)
                                        {
                                            OutputMethod.outputOnScreen(temp);
                                        }
                                        else
                                        {
                                            delShowOnScreen = OutputMethod.errorOutputOnScreen;
                                            delShowOnScreen("Кола з заданим радiусом немає у списку об'єктiв!\n");
                                        }
                                    }
                                    break;

                                case 2:
                                    {
                                        String value;
                                        delShowOnScreen("Введiть шуканий рядок: ");
                                        while ((value = Console.ReadLine()) == "");

                                        List<CircleInscribedInSquareWithLegend> temp = Utilities.findSubstringIn(figures, value);
                                        if (temp.Count != 0)
                                        {
                                            OutputMethod.outputOnScreen(temp);
                                        }
                                        else
                                        {
                                            delShowOnScreen = OutputMethod.errorOutputOnScreen;
                                            delShowOnScreen("У списку об'єктiв немає кола з написом, текст якого мiстить заданий рядок!\n");
                                        }
                                    }
                                    break;
                            }
                            
                        }
                        else
                        {
                            delShowOnScreen = OutputMethod.errorOutputOnScreen;
                            delShowOnScreen("Немає даних!\n");
                        }
                        break;

                    case 8:
                        //Розрахунку статистичної функцiї, щоб охарактеризувати данi
                        if (figures.List.Count != 0)
                        {
                            Console.WriteLine("Яку функцiю бажаєте розраховувати?");
                            Console.WriteLine("1 - середнє геометричне");
                            Console.WriteLine("2 - середнє гармонiйне");
                            Console.Write("Функцiя: ");
                            int ch;
                            while ((ch = Utilities.getIntFromConsole()) < 1 || ch > 2)
                            {
                                delShowOnScreen = OutputMethod.errorOutputOnScreen;
                                delShowOnScreen("Тiльки 1 або 2\n");
                                delShowOnScreen = OutputMethod.simplyOutputOnScreen;
                            }
                            switch (ch)
                            {
                                case 1:
                                    statisticDelegate = Utilities.averageGeometric;
                                    break;

                                case 2:
                                    statisticDelegate = Utilities.averageGarmonic;
                                    break;
                            }
                            statisticDelegate(figures.List);
                        }
                        else
                        {
                            delShowOnScreen = OutputMethod.errorOutputOnScreen;
                            delShowOnScreen("Немає даних для розрахунку функцiї!\n");
                        }
                    break;

                    case 9:
                        //Додання об'єкту до поточного списку
                        figures = figures + addNewObject();
                        //Повідомлення спостерігачам, що кількість об'єктів змінено
                        figures.notifyObservers(1);
                        break;
                }
            } while (choice != 0);//Якщо 0 - вихід з програми
        }

        private void createNewObjectWithObservers()
        {
            figures = new FiguresOnScreen();
            figures.addObserver(new ConsoleObserver());
            figures.addObserver(new FileObserver());

        }
        //Функція введення даних
        private void inputData()
        {
            createNewObjectWithObservers();
            Console.Write("Введiть кiлькiсть об'єктiв(не бiльше за 10): ");
            int amount;
            while ((amount = Utilities.getIntFromConsole()) <= 0 || amount > 10)
            {
                delShowOnScreen = OutputMethod.errorOutputOnScreen;
                delShowOnScreen("Кiлькiсть об'єктiв не може бути менше одиницi!\n");
                delShowOnScreen = OutputMethod.simplyOutputOnScreen;
            }

            int i = 0;
            while (i < amount)
            {
                delShowOnScreen = OutputMethod.simplyOutputOnScreen;
                delShowOnScreen("\nЗаповнення " + (i + 1).ToString() + "-го об'екта: \n");
                figures = figures + addNewObject();
                i++;
            }
        }

        //Функція додання одного об'єкту
        private CircleInscribedInSquareWithLegend addNewObject()
        {
            double x, y, radius;
            Circle localCircle = new Circle();
            delShowOnScreen("Введiть х(у дiапазонi вiд 0 до 700): ");
            x = Utilities.getDoubleFromConsole();
            localCircle.X = x;//Присвоювання відбувається тут, бо властивість у разі помилки повідомляє користувача
            //що значення не потрапляють у задані межі, і полю буде присвоєно інше значення
            delShowOnScreen("Введiть y(у дiапазонi вiд 0 до 500): ");
            y = Utilities.getDoubleFromConsole();
            localCircle.Y = y;
            delShowOnScreen("Введiть радiус вписаного кола: ");
            while ((radius = Utilities.getDoubleFromConsole()) <= 0)
            {
                delShowOnScreen = OutputMethod.errorOutputOnScreen;
                delShowOnScreen("Радiус вписаного кола не може бути вiд'ємною величиною!\n");
                delShowOnScreen = OutputMethod.simplyOutputOnScreen;
            }
            localCircle.Radius = radius;

            delShowOnScreen("Сторона квадрата розраховується автоматично!\n");
            delShowOnScreen("Введiть довжину напису у см: ");
            float length;
            while ((length = (float)Utilities.getDoubleFromConsole()) <= 0)
            {
                delShowOnScreen = OutputMethod.errorOutputOnScreen;
                delShowOnScreen("Довжина напису на колi не може бути вiд'ємною величиною!\n");
                delShowOnScreen = OutputMethod.simplyOutputOnScreen;
            }
            delShowOnScreen("Введiть текст напису(не бiльше 30 символiв, iнше буде обрiзано): \n");
            String text = Console.ReadLine();
            delShowOnScreen("Введiть нахил тексту(в межах вiд 1 до 180): ");
            int tilt;
            while ((tilt = Utilities.getIntFromConsole()) <= 0 || tilt > 180)
            {
                delShowOnScreen = OutputMethod.errorOutputOnScreen;
                delShowOnScreen("Кут нахилу тексту на колi повинен знаходитися у вiдповiдних межах!\n");
                delShowOnScreen = OutputMethod.simplyOutputOnScreen;
            }

            return new CircleInscribedInSquareWithLegend(
                localCircle, new LegendOnCircle(localCircle, new Legend(length, text), tilt));
        }
    }
}
