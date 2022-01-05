using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeWebApplication.Models
{
    public class Student
    {
        string fname;
        string lName;
        DateTime dateOfBirth;
        string email;
        int yearsOfStudies;

        public Student(string fname, string lName, DateTime dateOfBirth, string email, int yearsOfStudies)
        {
            this.Fname = fname;
            this.LName = lName;
            this.DateOfBirth = dateOfBirth;
            this.Email = email;
            this.YearsOfStudies = yearsOfStudies;
        }

        public Student()
        {

        }

        public string Fname { get => fname; set => fname = value; }
        public string LName { get => lName; set => lName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Email { get => email; set => email = value; }
        public int YearsOfStudies { get => yearsOfStudies; set => yearsOfStudies = value; }
    }
}