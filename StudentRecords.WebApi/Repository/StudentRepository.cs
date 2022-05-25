using AutoMapper;
using Newtonsoft.Json;
using StudentRecords.WebApi.Models;
using StudentRecords.WebApi.Models.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecords.WebApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private IMapper _mapper;

        public StudentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<StudentDto> CreateUpdateStudent(StudentDto studentDto)
        {
            //use json object
            //Student student = _mapper.Map<StudentDto, Student>(studentDto);
            //if (student.StudentId > 0)
            //{
            //}
            //else
            //{
            //}
            //await _db.SaveChangesAsync();
            //return _mapper.Map<Student, StudentDto>(student);
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentDto> GetStudentById(int studentId)
        {
            using (StreamReader readStudent = File.OpenText("Data/students.json"))
            {
                string json = readStudent.ReadToEnd();
                List<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(json);
                Student student = studentList.Where(x => x.StudentId == studentId).FirstOrDefault();
                return _mapper.Map<StudentDto>(student);
            }
        }     

        public async Task<IEnumerable<StudentDto>> GetStudents()
        {
            using (StreamReader readStudent = File.OpenText("Data/students.json"))
            {
                string json = readStudent.ReadToEnd();
                List<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(json);
                return _mapper.Map<List<StudentDto>>(studentList);
            }
        }

    }
}
