using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecords.WebApi.Models
{
    public class CourseEnrolment
    {
        [Key]
        public string EnrolmentId { get; set; }
        public string AcademicYear { get; set; }
        public string YearOfStudy { get; set; }
        public string Occurrence { get; set; }
        public string ModeOfAttendance { get; set; }
        public string EnrolmentStatus { get; set; }
        public DateTime CourseEntryDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public Course Course { get; set; }
    }
}
