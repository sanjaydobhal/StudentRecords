using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentRecords.Web.Models;
using StudentRecords.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRecords.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService )
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> StudentIndex()
        {
            List<StudentDto> studentList = new();
            var response = await _studentService.GetAllStudentsAsync<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                studentList = JsonConvert.DeserializeObject<List<StudentDto>>(Convert.ToString(response.Result));
            }
            return View(studentList);
        }

        public async Task<IActionResult> StudentCreate()
        {
            StudentDto studentDto = new();      
            //creating default first row for enrolling course... We can enroll for course using add more button
            studentDto.CourseEnrolment = new List<CourseEnrolmentDto>() { new CourseEnrolmentDto() { EnrolmentId = "1", Course = new CourseDto { CourseCode = "", CourseName = "" } } };
            return View(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> StudentCreate(StudentDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _studentService.CreateStudentAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(StudentIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> StudentEdit(int studentId)
        {
            var response = await _studentService.GetStudentByIdAsync<ResponseDto>(studentId);
            if (response != null && response.IsSuccess)
            {
                StudentDto model = JsonConvert.DeserializeObject<StudentDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentEdit(StudentDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _studentService.UpdateStudentAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(StudentIndex));
                }
            }
            return View(model);
        }
    }
}
