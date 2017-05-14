using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2_lab_5_7
{
    class StudyGroup
    {
        private String groupCipher;
        private String faculty;
        private String speciality;
        private Date dateOfEnrollment;

        public string GroupCipher
        {
            get
            {
                return groupCipher;
            }

            set
            {
                groupCipher = value;
            }
        }
        public string Faculty
        {
            get
            {
                return faculty;
            }

            set
            {
                faculty = value;
            }
        }
        public string Speciality
        {
            get
            {
                return speciality;
            }

            set
            {
                speciality = value;
            }
        }
        internal Date DateOfEnrollment
        {
            get
            {
                return dateOfEnrollment;
            }

            set
            {
                dateOfEnrollment = value;
            }
        }

        public StudyGroup(String groupCipher, String faculty, String speciality, Date dateOfEnrollment)
        {
            GroupCipher = groupCipher;
            Faculty = faculty;
            Speciality = speciality;
            DateOfEnrollment = dateOfEnrollment;
        }
    }
}
