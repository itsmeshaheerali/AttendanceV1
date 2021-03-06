using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
	public class LeaveApplication
	{
		public int ID { get; set; }
        public string Reason { get; set; }
        [DisplayFormat(DataFormatString = "{0:dddd,MMMM d yyyy}")]
        public DateTime from { get; set; }
        public float NoOfDays { get; set; }
        public string ResponseMessage { get; set; }
        public string MedicalCertificate { get; set; }
        public bool? Haspermission { get; set; }
        public int LeaveType { get; set; }
        public bool AppliedByAdmin { get; set; }

        [Required(ErrorMessage = "Please select a Employee")]
		public int EmployeeID { get; set; }

		[ForeignKey("EmployeeID")]
		public virtual Employee employee { get; set; }

	}
}