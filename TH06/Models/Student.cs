using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH06.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public StudentAddress StudentAddress { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}