using CourseWorkOOP2.Interfaces;
using System;
using System.IO;


namespace CourseWorkOOP2.Observers
{
    class FileObserver : IObserver
    {
        //Перевизначення методу інтерфейса
        //Дописує у файл повідомлення, яке буде передано
        public void handleEvent(String message)
        {
            using (StreamWriter file = new StreamWriter(
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                            @"\LogFile_Observer.txt", true))/////////****
            {
                file.WriteLine(message);
            }
        }
    }
}
