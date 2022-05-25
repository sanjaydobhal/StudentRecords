using StudentRecords.Web.Models;
using StudentRecords.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StudentRecords.Web.Services
{
    public class StudentService : BaseService, IStudentService
    {
        private readonly IHttpClientFactory _clientFactory;

        public StudentService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
             
        public async Task<T> CreateStudentAsync<T>(StudentDto studentDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = studentDto,
                Url = SD.StudentApiBase + "/api/students"
            });
        }

        public async Task<T> DeleteStudentAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.StudentApiBase + "/api/students/"+id
            });
        }

        public async Task<T> GetAllStudentsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.StudentApiBase + "/api/students"
            });
        }

        public async Task<T> GetStudentByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.StudentApiBase + "/api/students/" + id
            });
        }

        public async Task<T> UpdateStudentAsync<T>(StudentDto studentDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = studentDto,
                Url = SD.StudentApiBase + "/api/students"
            });
        }
    }
}
