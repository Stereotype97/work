using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace lab1
{
   
    class Program
    {
        //Константы
        const double A = -0.5;
        const double B = 0.5;
        const double H = 0.05;
        const int SERIES_AMOUNT = 15;
        const double EPS = 0.01;

        static void Main(string[] args)
        {   
            Aproximation[] aproxArray = new Aproximation[SERIES_AMOUNT];
            int i = -1;
            Console.SetWindowSize(150, 60);
            do
            {
                i++;
                aproxArray[i] = new Aproximation(A, B, H, i + 1);
                aproxArray[i].showTable();
                aproxArray[i].showGraph();
                Console.ReadKey();
            } while (aproxArray[i].getEps() > EPS); //Увеличение количества членов ряда, пока не будет достигнута
                                                    //заданная точность с отображением таблицы зависимости и 
                                                    //линейных гистограм аппроксимации

            Console.ReadKey();
        }
    }
}
