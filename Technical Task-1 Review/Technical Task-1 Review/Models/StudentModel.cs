using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Technical_Task_1_Review.Models
{
    public class StudentModel
    {

        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }

        public string dob { get; set; }
        public string gender { get; set; }
        public int teacher { get; set; }
    }
}