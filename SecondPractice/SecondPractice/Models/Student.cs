﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondPractice.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DoB { get; set; }
        public string Gender { get; set; }  
        public float Cgpa { get; set; }
    }
}