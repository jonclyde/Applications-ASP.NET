using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Data
{
	public class OrgTask
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public int Urgency { get; set; }
		public int Importance { get; set; }
		public int Difficulty { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime DeadLine { get; set; }
		[ForeignKey("UserId")]
		public IdentityUser User { get; set; }
		public string UserId { get; set; }
		public bool? Status { get; set; }
		public DateTime DateComplete { get; set; }
		[ForeignKey("LeaveTypeId")]
		public TaskType TaskType { get; set; }
		public int LeaveTypeId { get; set; }
	}
}
