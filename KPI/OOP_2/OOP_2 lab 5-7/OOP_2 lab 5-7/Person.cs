using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2_lab_5_7
{
    class Person
    {
        private String surname;
        private String name;
        public Date Birthday { get; private set; }
   
        private readonly String sex;

        public Person(string surname, string name, Date birthday, string sex)
        {
            Surname = surname;
            Name = name;
            Birthday = birthday;
            this.sex = sex;
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }
        }
    }
}
