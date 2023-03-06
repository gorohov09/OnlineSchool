using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.App.Common.Interfaces.Services
{
    public interface IEmailService
    {
        void SendEmailAsync(string email, string subject, string message);
    }
}
