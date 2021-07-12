using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3FirtApi.Models
{
    public class Student
    {
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentIndex { get; set; }
        public string DateOfBirth { get; set; }
        public string FieldOfStudy { get; set; }
        public string StudyMode { get; set; }
        public string StudentEmail { get; set; }
        public string StudentFatherName { get; set; }
        public string StudentMotherName { get; set; }
        
        public override string ToString()
        {
            return StudentFirstName + "," + StudentLastName + "," + StudentIndex + "," + DateOfBirth + "," + FieldOfStudy + "," + StudyMode + "," + StudentEmail + "," + StudentFatherName + "," + StudentMotherName;
        }
      
    }

}
