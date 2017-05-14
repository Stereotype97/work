using CourseWorkOOP2.Interfaces;

namespace CourseWorkOOP2
{
    //Інтерфейс джерела (патерн Джерело-Спостерігач)
    interface IObserved
    {
        void addObserver(IObserver observer);
        void removeObserver(IObserver observer);
        void notifyObservers(int amount);

    }
}
