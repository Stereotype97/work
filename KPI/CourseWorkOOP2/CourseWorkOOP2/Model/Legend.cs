using System;

namespace CourseWorkOOP2
{
    [Serializable]
    //Для серіалізації об'єкта похідного класу
    class Legend
    {
        float length;
        String text;
        //Конструктор за замовчуванням
        public Legend() : this(1f, "A") { }

        //Провідний конструктор
        public Legend(float length, String text)
        {
            Length = length;
            Text = text;
        }
        //Властивості
        public float Length { get {return length; }
            set { length = value; }
        }
        public string Text { get { return text; }
            set { text = value; }
        }
    }
}
