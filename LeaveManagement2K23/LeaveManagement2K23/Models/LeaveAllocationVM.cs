using System.ComponentModel.DataAnnotations;

namespace LeaveManagement2K23.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }
        
        [Display(Name = "Number of Days")]
        [Required]
        [Range(1, 50, ErrorMessage = "Number of days must be between 1 and 50")]
        public int NumberOfDays { get; set; }
        
        [Required]
        [Display(Name = "Allocation period")]
        public int Period { get; set; }
        public LeaveTypeVM? LeaveType { get; set; }
    }
}
