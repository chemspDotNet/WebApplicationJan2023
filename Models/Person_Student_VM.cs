using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Person_Student_VM
    {
        public Person person { get; set; }
        Student s;

        public Person_Student_VM()
        {
          //  p= new Person();
            s= new Student();

        }
    }
}