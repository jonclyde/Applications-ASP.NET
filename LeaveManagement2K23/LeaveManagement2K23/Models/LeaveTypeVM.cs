using System.ComponentModel.DataAnnotations;

namespace LeaveManagement2K23.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Display(Name = "Leave Type")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Default Number of Days")]
        //range of 1 to 25
        [Range(1, 25, ErrorMessage = "Please enter a validate number")]
        public int DefaultDays { get; set; }

    }
}
