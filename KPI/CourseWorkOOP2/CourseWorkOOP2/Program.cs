using System;

namespace CourseWorkOOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 40); //Задання розмірів консолі при запуску
            Menu.showMenu();//Показати користувачу меню
            Menu menu = new Menu();
            menu.process();//Запустити головний процес
        }
    }
}
