using AutoMapper;
using StudentRecords.WebApi.Models;
using StudentRecords.WebApi.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecords.WebApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<StudentDto, Student>();
                config.CreateMap<Student, StudentDto>();
                config.CreateMap<CourseEnrolmentDto, CourseEnrolment>();
                config.CreateMap<CourseEnrolment, CourseEnrolmentDto>();
                config.CreateMap<CourseDto, Course>();
                config.CreateMap<Course, CourseDto>();
            });
            return mappingConfig;
        }
    }
}
