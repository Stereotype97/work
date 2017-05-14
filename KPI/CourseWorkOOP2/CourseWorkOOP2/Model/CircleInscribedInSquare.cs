using System;

namespace CourseWorkOOP2
{
    [Serializable]
    //Для серіалізації об'єкта похідного класу
    class CircleInscribedInSquare
    {
        //Приклад композиції
        Circle circle;
        Square square;

        public CircleInscribedInSquare()
        {
            Circle = new Circle();
            Square = new Square();
        }
        //Конструктор, який приймає об'єкт класу Коло і розраховує параметри об'єкта Квадрат(коло вписане в квадрат)
        public CircleInscribedInSquare(Circle circle) {
            
            this.circle = circle;
            Square = new Square();
            square.setCenter(circle.X, circle.Y);
            square.setSide(2 * circle.Radius);
        }
        //Конструктор, який приймає об'єкт класу Квадрат і розраховує параметри об'єкта Коло(квадрат описує коло)
        public CircleInscribedInSquare(Square square) {
            this.square = square;
            Circle = new Circle();
            circle.X = square.getCenter().X;
            circle.Y = square.getCenter().Y;
            circle.Radius = square.getSide() / 2;
        }
        //Властивості
        internal Circle Circle
        {
            get
            {
                return circle;
            }

            set
            {
                circle = value;
            }
        }
        internal Square Square
        {
            get
            {
                return square;
            }

            set
            {
                square = value;
            }
        }
    
    }
}
