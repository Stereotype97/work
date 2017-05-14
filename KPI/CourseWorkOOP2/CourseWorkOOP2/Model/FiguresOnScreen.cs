using CourseWorkOOP2.Interfaces;
using System;
using System.Collections.Generic;

namespace CourseWorkOOP2
{
    public delegate void ObserversDelegate(String message);//Делегат для реалізації патерну Джерело - Спостерігач
    class FiguresOnScreen : IObserved//Клас - джерело
    {
        public ObserversDelegate observersDelegate;
        //Список кіл вписаних до квадрату з написом
        private List<CircleInscribedInSquareWithLegend> list = new List<CircleInscribedInSquareWithLegend>();
        //Було створено структуру даних List<> тому, що необхідно динамічно додавати об'єкти до списку,
        //List<> представляю собою строго типізовану структуру, доступатися до єлементів якої можна по індексу
        
        //Індексатор для звернення до об'єктів списку list
        public CircleInscribedInSquareWithLegend this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
                List[index] = value;
            }

        }

        internal List<CircleInscribedInSquareWithLegend> List { get => list; set => list = value; }
        //Перевантажений оператор +, що додає до списку новий об'єкт
        public static FiguresOnScreen operator+(FiguresOnScreen obj, CircleInscribedInSquareWithLegend add)
        {
            obj.List.Add(add);
            return obj;
        }
        //Реалізація методів патерну Джерело - Спостерігач
        public void addObserver(IObserver observer)
        {
            observersDelegate += observer.handleEvent;
        }

        public void removeObserver(IObserver observer)
        {
            observersDelegate -= observer.handleEvent;
        }

        public void notifyObservers(int amount)
        {
            observersDelegate("Було додано об'єктiв: " + amount + ". " +
                DateTime.Now.TimeOfDay.ToString().Substring(0, 8));//Поточний час
        }

    }
}
