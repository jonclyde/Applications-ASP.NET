using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using HR.LeaveManagement.Application.Models.Email;

namespace HR.LeaveManagement.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}