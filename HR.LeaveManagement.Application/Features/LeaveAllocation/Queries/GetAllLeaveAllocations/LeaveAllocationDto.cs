using HR.LeaveManagement.Application.Features.LeaveTypeFeature.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;

public class LeaveAllocationDto
{
    public int Id { get; set; }

    public int NumberOfDays { get; set; }

    //Dto不應參照Domain Object =>e.g.直接參照LeaveType
    //關聯性資料應像此處參照Dto，若沒有就建一個
    public required LeaveTypeDto LeaveType { get; set; }    
    public int LeaveTypeId { get; set; }

    public int Period { get; set; }

}
