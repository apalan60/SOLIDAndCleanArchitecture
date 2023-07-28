﻿using HR.LeaveManagement.Application.Models.EMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EMailMessage email);
}