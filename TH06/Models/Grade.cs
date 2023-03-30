﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TH06.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}