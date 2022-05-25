using StudentRecords.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecords.Web.Services.IServices
{
    public interface IStudentService : IBaseService
    {
        Task<T> GetAllStudentsAsync<T>();
        Task<T> GetStudentByIdAsync<T>(int id);
        Task<T> CreateStudentAsync<T>(StudentDto studentDto);
        Task<T> UpdateStudentAsync<T>(StudentDto studentDto);
        Task<T> DeleteStudentAsync<T>(int id);
    }
}
