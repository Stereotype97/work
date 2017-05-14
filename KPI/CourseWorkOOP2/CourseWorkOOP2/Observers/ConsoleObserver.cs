using CourseWorkOOP2.Interfaces;
using System;

namespace CourseWorkOOP2.Observers
{
    //Класс Спостерігача(Консолі)
    class ConsoleObserver : IObserver//Розширення класу за допомогою інтерфейсу
    {
        //Перевизначення методу інтерфейса
        //Пише на екрані консолі Спостерігач: і повідомлення, яке буде передано
        public void handleEvent(String message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Спостерiгач: ");
            Console.ResetColor();
            Console.WriteLine(message);
        }
    }
}
