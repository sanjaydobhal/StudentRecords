using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecords.Web.Models
{
    public class CourseEnrolmentDto
    {
        public string EnrolmentId { get; set; }
        public string AcademicYear { get; set; }
        public string YearOfStudy { get; set; }
        public string Occurrence { get; set; }
        public string ModeOfAttendance { get; set; }
        public string EnrolmentStatus { get; set; }
        public DateTime CourseEntryDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public CourseDto Course { get; set; }
    }
}
