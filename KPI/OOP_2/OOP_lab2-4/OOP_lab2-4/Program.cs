using System;

namespace OOP_lab2_4
{
    class Program
    {
        static void Main(string[] args)
        {
           // Date date = CardAccountAdvanced.FirstDateOfEnrollment;
            CardAccountAdvanced card = new CardAccountAdvanced();
            card.display();
            card = new CardAccountAdvanced(new Date());
            card.display();
            card = new CardAccountAdvanced("Скоробогатский", "Дмитрий", new Date(22, 6, 1997), new Date(28, 3, 2017), Education.IncompleteHigher, false);
            card.showStaticField();
            card.display();

            Console.WriteLine("Приведение к строке: " + (String)card);
            Console.WriteLine("Оператор+ : card + \'Николенко\' :" + (String)(card + "Николенко"));
            
            Console.WriteLine("Приведение к логической величине: " + (bool)card + '\n');
            Console.WriteLine("!card = " + !card);
            Console.WriteLine("card == new CardAccountAdvanced() :" + (card == new CardAccountAdvanced()));
            Console.WriteLine("card.Equals(new CardAccountAdvanced()) :" + (card.Equals(new CardAccountAdvanced())));

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Новый класс с статическим массивом производного класса:");
            Console.ForegroundColor = ConsoleColor.White;
            LibraryCards library = new LibraryCards();
            library.setLibraryArray();
            CardAccountAdvanced.topForDisplay();
            for (int i = 0; i < LibraryCards.size; i++)
            {
                library[i].displayFields();
            }
            
            System.Console.ReadKey();
        }
    }
}
