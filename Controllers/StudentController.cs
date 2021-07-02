using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_core.Models;
using EF_core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EF_core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("api/student")]
        public List<Student> GetAll()
        {
            var students = _studentService.GetAll();
            return students;
        }
        [HttpPost("api/Create/student")]
        public Student CreateStudent(Student student)
        {
            _studentService.SaveStudent(student);
            return student;
        }

        [HttpPut("api/Edit/student")]
        public List<Student> EditStudent(Student student, int id)
        {
            var studentEdited = _studentService.EditStudent(student, id);
            return studentEdited;
        }
        [HttpDelete("api/Delete/Student")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.Get(id);
            if (student == null)
            {
                return StatusCode(404);
            }
            else
            {
                _studentService.DeleteStudent(id);
                return StatusCode(200);
            }
        }

        [HttpGet("api/Student/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.Get(id);
            if (student == null)
            {
                return new JsonResult(new { StatusCode = 404 });
            }
            else
            {
                return new JsonResult(new { StatusCode = 200, data = student });
            }
        }

        [HttpGet("api/Filter/{firstName}/{lastName}/{city}")]
        public IActionResult Filter(string firstName, string lastName, string city)
        {
            var students = _studentService.Filter(firstName, lastName, city);
            if(students == null)
            {
                return new JsonResult(new { StatusCode = 404 });
            }else{
                 return new JsonResult(new { StatusCode = 200, data = students });
            }
        }
    }
}