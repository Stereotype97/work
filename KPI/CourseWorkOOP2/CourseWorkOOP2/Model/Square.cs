using System;
using CourseWorkOOP2.Interfaces;

namespace CourseWorkOOP2
{
    [Serializable]
    //Для серіалізації об'єкта похідного класу
    class Square : IPerimetrical, IHavingArea ////Має периметр і площу
    {
        private Point center = new Point(); //Приклад агрегації
        protected double side = 10.0; //Присвоювання значення полю перед конструктором
        //Конструктор за замовчуванням
        public Square()
        {
            side = 5.0; //Присвоювання значення у конструкторі
        }
        //Конструктор ініціалізації
        public Square(double side, double x, double y)
        {
            center = new Point(x, y);
            this.side = side; ////Присвоювання значення у методі
        }

        //Інкапсуляція полів класу, без застосування властивостей
        public void setCenter(double x, double y)
        {
            center = new Point(x, y);
        }
        public Point getCenter()
        {
            return center;
        }
        public double getSide()
        {
            return side;
        }
        public void setSide(double side)
        {
            this.side = side;
        }
        ///Реалізація методів інтерфейсів
        //Розрахунок периметру квадрата
        public double confirmPerimetr()
        {
            return 4 * side;
        }
        //Розрахунок площі квадрата
        public double confirmArea()
        {
            return Math.Pow(side, 2);
        }
    }
}
