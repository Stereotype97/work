using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2_lab_5_7
{
    class StudyGroupOfStudents : StudyGroup
    {
        public int AmountStudents { get; set; }
        Student[] array = new Student[10];

        ArrayList list = new ArrayList(); 
        static double averageAgeOfStudents;

        public StudyGroupOfStudents(String groupCipher, String faculty, String speciality, Date dateOfEnrollment, int amount):
            base(groupCipher, faculty, speciality, dateOfEnrollment)
        {
            Random rand = new Random();
            AmountStudents = amount;

            StudyGroup sg = new StudyGroup(groupCipher, faculty, speciality, dateOfEnrollment);
            //Заповнення динамічного масиву
            for (int i = 0; i < amount; i++)
            {
                list.Add(new Student("Surname" + (i + 1).ToString(), "Name" + (i + 1).ToString(),
                    new Date(rand.Next(2) + 1997, rand.Next(1, 13), rand.Next(1, 30)), "Sex", sg));
            }
            //Заповнення статичного масиву
            fillArray(sg);
	
            showList();
            int sum = 0;
            foreach (Student st in list)
            {
                sum += st.Age;
            }
            averageAgeOfStudents = (double)sum / amount;
        }

        public void showList()
        {
            Console.WriteLine("ArrayList");
            Student.topForDisplay();
            foreach (Student st in list)
            {
                st.displayFields();
            }
        }

        public void showArray()
        {
            Console.WriteLine("Array");
            Student.topForDisplay();
            foreach (Student st in array)
            {
                st.displayFields();
            }
        }
        public static double AverageAgeOfStudents
        {
            get
            {
                return averageAgeOfStudents;
            }
        }

        private void fillArray(StudyGroup sg)
        {
            array[0] = new Student("Betin", "Vlad", new Date(1997, 12, 1), "men", sg);
            array[1] = new Student("Bondarenko", "Andriy", new Date(1997, 6, 3), "men", sg);
            array[2] = new Student("Bondarenko", "Maxim", new Date(1998, 5, 4), "men", sg);
            array[3] = new Student("Mishenko", "Sasha", new Date(1997, 3, 1), "women", sg);
            array[4] = new Student("Mozhayskiy", "Mihaylo", new Date(1998, 1, 28), "men", sg);
            array[5] = new Student("Oliynyk", "Bogdan", new Date(1997, 4, 6), "men", sg);
            array[6] = new Student("Pyrogovska", "Tanya", new Date(1997, 8, 14), "women", sg);
            array[7] = new Student("Pogrebnyak", "Andriy", new Date(1997, 4, 17), "men", sg);
            array[8] = new Student("Skorobogatskii", "Dima", new Date(1997, 6, 22), "men", sg);
            array[9] = new Student("Skochko", "Bogdan", new Date(1998, 12, 28), "men", sg);
        }

        public void putElementFromArrayToList(int indexArray, int indexList)
        {
            bool isErrorListBound = false;
            if (indexArray > 9 || indexArray < 0)
                indexArray = 5;
            if (indexList > list.Count - 1 || indexList < 0)
                isErrorListBound = true;

            if (isErrorListBound)
            {
                list.Add(array[indexArray]);
            }
            else
            {
                list.Insert(indexList, array[indexArray]);
            }
        }

        public void findAndDeleteObjectByNameFromList(String name)
        {
            ArrayList local = new ArrayList();
            foreach  (Student st in list)
            {
                if(st.Name == name)
                {
                    local.Add(st);
                }
            }
            for(int i = local.Count - 1; i >=0; i--)
            {
                list.Remove(local[i]);
            }

        }

        public Student[] findAndDeleteObjectByNameFromArray(String name)
        {
            int index;
            while(isContains(array, name, out index))
            {
                array = deleteByIndex(array, index);
            }
            return array;
        }

        private bool isContains(Student[] arr, String str, out int index)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i].Name == str)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        private Student[] deleteByIndex(Student[] arr, int index)
        {
            for (int i = index; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            Student[] temp = new Student[arr.Length - 1];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                temp[i] = arr[i];
            }
            return temp;
        }

        public void sortListByAge() {
            list.Sort(Comparer<Student>.Create(comparing));          
        }
        public void sortArrayByAge()
        {
            Array.Sort(array, Comparer<Student>.Create((x, y) => x.Age - y.Age));
        }
        private int comparing(Student x, Student y)
        {
            return x.Age - y.Age;
        }
      
    }
}
