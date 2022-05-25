using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentRecords.WebApi.Models;
using StudentRecords.WebApi.Models.Dto;
using StudentRecords.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecords.WebApi.Controllers
{
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        protected ResponseDto _response;
        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<StudentDto> studentDtos = await _studentRepository.GetStudents();
                _response.Result = studentDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;           
        }

        [HttpGet]
        [Route("{studentId}")]
        public async Task<object> Get(int studentId)
        {
            try
            {
                StudentDto studenttDto = await _studentRepository.GetStudentById(studentId);
                _response.Result = studenttDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]       
        public async Task<object> Post([FromBody] StudentDto studentDto)
        {
            try
            {
                StudentDto model = await _studentRepository.CreateUpdateStudent(studentDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
