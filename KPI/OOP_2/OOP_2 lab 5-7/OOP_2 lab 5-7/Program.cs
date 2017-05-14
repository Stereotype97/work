using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2_lab_5_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of count of arrayList's elements: ");
            int amount;
            while (!Int32.TryParse(Console.ReadLine(), out amount)){
                Console.Write("Try again: ");
            }
            StudyGroupOfStudents group = new StudyGroupOfStudents("TI-51", "TEF", "PI", new Date(2015, 9, 1), amount);
            Console.WriteLine("Средний возраст студентов: " + StudyGroupOfStudents.AverageAgeOfStudents);

            group.putElementFromArrayToList(-1, 20);
            //group.showList();
            group.findAndDeleteObjectByNameFromList("Name1");
            group.sortListByAge();
            group.showList();

            group.showArray();
            group.findAndDeleteObjectByNameFromArray("Bogdan");
            group.sortArrayByAge();
            group.showArray();
            Console.ReadKey();
        }
    }
}
