using System;
using System.Collections.Generic;
using System.Linq;
using EF_core.Services;
using EF_core.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EF_core.Services{
    public class StudentService : IStudentService
    {   
         private StudentContext _studentContext;

         public StudentService(StudentContext studentContext)
         {
             _studentContext = studentContext;

         }

        public Student Get(int id) => _studentContext.Students.Find(id);
        public List<Student> Filter(string firstName, string lastName, string city) => _studentContext.Students.Where(
             m => m.FirstName.Contains(firstName)
             && m.LastName.Contains(lastName)
             && m.City.Contains(city)).ToList();
        public List<Student> SaveStudent(Student student)
        {
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
            var lsStudent = _studentContext.Students.ToList();
            return lsStudent;
        }
        public List<Student> GetAll(){
            List<Student> students = _studentContext.Students.ToList();
            return students;
        }

        public List<Student> EditStudent(Student student, int id){
            Student currentStudent = _studentContext.Students.Find(id);
            if(currentStudent == null){
                return new List<Student>();
            }else{
                currentStudent.FirstName = student.FirstName;
                currentStudent.LastName = student.LastName;
                currentStudent.City = student.City;
                currentStudent.State = student.State;

                _studentContext.Entry(currentStudent).State = EntityState.Modified;
                _studentContext.SaveChanges();
            }
            return _studentContext.Students.ToList();
        }
        public void DeleteStudent(int id){
            Student student = _studentContext.Students.Find(id);
            _studentContext.Students.Remove(student);
             _studentContext.SaveChanges();
        }
    }
}