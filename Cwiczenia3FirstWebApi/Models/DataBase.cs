using Cwiczenia3FirtApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3FirstWebApi.Models
{
    public class DataBase
    {
        public static List<Student> getDataBase() {
            var path = "Dane/dane.csv";
            FileInfo fi = new FileInfo(path);
            var listOfStudents = new List<Student>();
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] students = line.Split(",");

                    listOfStudents.Add(new Student
                    {
                        StudentFirstName = students[0],
                        StudentLastName = students[1],
                        StudentIndex = students[2],
                        DateOfBirth = students[3],
                        FieldOfStudy = students[4],
                        StudyMode = students[5],
                        StudentEmail = students[6],
                        StudentFatherName = students[7],
                        StudentMotherName = students[8]
                    });
                }
            }
            return listOfStudents;
        }

        public static void AddToFile(Student student) {
            string path = "Dane/dane.csv";
            File.AppendAllText(path,"\n"+student.ToString());
        }

        public static void OverwriteFile(List<Student>list) {
            string path = "Dane/dane.csv";
            StreamWriter sw = new StreamWriter(path);
            foreach (Student s in list)
            {
                sw.WriteLine(s);
            }
            sw.Close();
        }

    }
}
