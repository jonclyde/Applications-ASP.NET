using System.ComponentModel.DataAnnotations;

namespace LeaveManagement2K23.Models
{
    public class EmployeeListVM
    {
        public string Id { get; set; }
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Display(Name = "Email address")]
        public string Email { get; set; }
        [Display(Name = "Date Joined")]
        public string DataJoined { get; set; }
    }
}
