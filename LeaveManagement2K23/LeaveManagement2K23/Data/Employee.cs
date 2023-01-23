﻿using Microsoft.AspNetCore.Identity;

namespace LeaveManagement2K23.Data
{
    public class Employee : IdentityUser
    {
        public string ?Firstname { get; set; }
        public string ?Lastname { get; set; }
        public string ?TaxId { get; set; }
        public DateTime DataOfBirth { get; set; }
        public DateTime DataJoined { get; set; }
    }
}
