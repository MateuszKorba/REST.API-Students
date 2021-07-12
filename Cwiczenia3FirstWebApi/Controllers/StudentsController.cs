using Cwiczenia3FirstWebApi.Models;
using Cwiczenia3FirtApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cwiczenia3FirtApi.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetStudents()
        {
            var listOfStudents = DataBase.getDataBase();
            return Ok(listOfStudents);
        }

        [HttpGet("{StudentIndex}")]
        public IActionResult GetStudentsByIndex([FromRoute] string StudentIndex)
        {
            var listOfStudents = DataBase.getDataBase();
            Student studentRes = null;
            foreach (var student in listOfStudents)
            {
                if (student.StudentIndex.Equals(StudentIndex))
                {
                    studentRes = student;
                }
            }
            if (studentRes != null)
            {
                return Ok(studentRes);
            }
            else
            {
                return NotFound("Nie znaleziono Studenta");
            }
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            var listOfStudents = DataBase.getDataBase();
            string pattern = "s[0-9]+";
            Regex regex = new Regex(pattern);
            bool isOK = true;
            foreach (PropertyInfo prop in typeof(Student).GetProperties())
            {
                if (prop.GetValue(student, null) == "")
                {
                    isOK = false;
                }
            }
            if (!regex.IsMatch(student.StudentIndex) && isOK == false)
            {
                return BadRequest("Zly format indexu Studenta\nZla liczba wprowadzonych danych");
            }
            else if (!regex.IsMatch(student.StudentIndex) && isOK == true)
            {
                return BadRequest("Zly format indexu Studenta");
            }
            else if (regex.IsMatch(student.StudentIndex) && isOK == false) {
                return BadRequest("Zla liczba wprowadzonych danych");
            }
            else
            {
                listOfStudents.Add(student);
                DataBase.AddToFile(student);
                return Ok("Student dodany!");
            }
        }

        
        [HttpPut("{StudentIndex}")]
        public IActionResult UpdateStudent([FromRoute] string StudentIndex, Student updatedStudent)
        {
            var listOfStudents = DataBase.getDataBase();
            Student studentRes = null;
            bool isOK = true;
            
            foreach (Student student in listOfStudents)
            {
                if (student.StudentIndex.Equals(StudentIndex))
                {
                    studentRes = student;
                }
            }
            foreach (PropertyInfo prop in typeof(Student).GetProperties())
            {
                if (prop.GetValue(updatedStudent, null) == "")
                {
                    isOK = false;
                }
            }
            if (studentRes != null)
            {
                if (updatedStudent.StudentIndex.Equals(studentRes.StudentIndex)) {
                    if (isOK == false) {
                        return BadRequest("Uzupelnij wszystkie pola");
                    }
                    else {
                        listOfStudents.Remove(studentRes);
                        listOfStudents.Add(updatedStudent);
                        DataBase.OverwriteFile(listOfStudents);
                        return Ok("Zaaktualizowano dane Studenta: " + updatedStudent);
                    }
                }
                else {
                    return BadRequest("Indexu studenta nie mozna zmienic");
                }
            }
            else
            {
                return NotFound("Nie znaleziono Studenta");
            }
        }
        
        [HttpDelete("{StudentIndex}")]
        public IActionResult DeleteStudent([FromRoute] string StudentIndex)
        {
            var listOfStudents = DataBase.getDataBase();
            Student studentRes = null;
            foreach (Student student in listOfStudents)
            {
                if (student.StudentIndex.Equals(StudentIndex))
                {
                    studentRes = student;
                }
            }
            if (studentRes != null)
            {
                listOfStudents.Remove(studentRes);
                DataBase.OverwriteFile(listOfStudents);
                return Ok("Student został usuniety");
            }
            else
            {
                return NotFound("Nie znaleziono Studenta");
            }
        }

    }
}