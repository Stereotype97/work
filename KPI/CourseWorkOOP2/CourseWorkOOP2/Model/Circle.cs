using System;

namespace CourseWorkOOP2
{
    [Serializable]
    //Для серіалізації об'єкта похідного класу
    class Circle : Point, IPerimetrical, IHavingArea //Має довжину(кола) і площу
    {
        public double Radius { get; set; } //Автоматична властивість
        public double Perimetr
        { //Властивіть тільки для читання
            get
            {
                return confirmPerimetr();
            }
        }
        public double Area
        {//Властивіть тільки для читання
            get
            {
                return confirmArea();
            }
        }
        //Конструктор за замовчуванням
        public Circle() : base()
        {
            Radius = 2.5;
        }
        //Конструктор з одним параметром
        public Circle(double radius) : base()
        {
            Radius = radius;
        }
        //Конструктор ініціалізації
        public Circle(double radius, double x, double y) : base(x, y)
        {
            Radius = radius;
        }
        ///Реалізація методів інтерфейсів
        //Розрахунок довжини поточного кола
        public double confirmPerimetr()
        {
            return 2 * Math.PI * Radius;
        }
        //Розрахунок площі поточного кола
        public double confirmArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

    }
}