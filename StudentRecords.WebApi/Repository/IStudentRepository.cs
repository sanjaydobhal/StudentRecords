using StudentRecords.WebApi.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecords.WebApi.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDto>> GetStudents();
        Task<StudentDto> GetStudentById(int studentId);
        Task<StudentDto> CreateUpdateStudent(StudentDto studentDto);
        Task<bool> DeleteStudent(int studentId);
    }
}
