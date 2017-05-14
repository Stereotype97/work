using System;

namespace CourseWorkOOP2
{
    [Serializable]
    //Для серіалізації об'єкта похідного класу
    class LegendOnCircle
    {
        //Агрегація
        Circle circle = new Circle();
        Legend legend = new Legend();

        public int TiltAngle { get; set; } = 75; //Автоматична властивість зі значенням за замовчуванням

        internal Legend Legend { get {return legend; } set { legend = value; } }

        internal Circle Circle { get { return circle; } set { circle = value; } }

        //Конструктор ініціалізації
        public LegendOnCircle(Circle circle, Legend legend, int tiltAngle) 
        {
            Circle = circle;
            Legend = legend;
            TiltAngle = tiltAngle;
        }


    }
}
