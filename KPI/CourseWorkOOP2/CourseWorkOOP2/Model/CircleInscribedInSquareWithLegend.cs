using System;

namespace CourseWorkOOP2
{
    [Serializable]
    //Для серіалізації об'єкта похідного класу
    class CircleInscribedInSquareWithLegend : CircleInscribedInSquare
    {
        LegendOnCircle legend;
        //Конструктор, який приймає об'єкт класу Коло і розраховує параметри об'єкта Квадрат(коло вписане в квадрат)
        public CircleInscribedInSquareWithLegend(Circle circle, LegendOnCircle legend) : base(circle)
        {
            Legend = legend;
        }
        //Конструктор, який приймає об'єкт класу Квадрат і розраховує параметри об'єкта Коло(квадрат описує коло)
        public CircleInscribedInSquareWithLegend(Square square, LegendOnCircle legend) : base(square)
        {
            Legend = legend;
        }

        internal LegendOnCircle Legend { get {return legend; }
            set { legend = value; }
        }
    }
}
