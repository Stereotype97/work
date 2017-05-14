using System;

namespace CourseWorkOOP2.Interfaces
{
    //Інтерфейс спостерігачів (патерн Джерело-Спостерігач)
    interface IObserver
    {
        void handleEvent(String message);
    }
}
