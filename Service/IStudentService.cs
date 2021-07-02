using System;
using System.Collections.Generic;
using EF_core.Models;

namespace EF_core.Services{
    public interface IStudentService
    {
        List<Student> SaveStudent(Student student);
        List<Student> GetAll();
        List<Student> EditStudent(Student student, int id);
        void DeleteStudent(int id);
        Student Get(int id);
        List<Student> Filter(string firstName, string lastName, string city);
    }
}