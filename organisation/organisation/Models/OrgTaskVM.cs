using Microsoft.AspNetCore.Identity;
using organisation.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace organisation.Models
{
	public class OrgTaskVM
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public int Urgency { get; set; }
		public int Importance { get; set; }
		public int Difficulty { get; set; }
		public int Score { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime DeadLine { get; set; }
		public IdentityUser User { get; set; }
		public string UserId { get; set; }
		public bool? Status { get; set; }
		public DateTime DateComplete { get; set; }
		public TaskType TaskType { get; set; }
		public int TaskTypeId { get; set; }
	}
}
