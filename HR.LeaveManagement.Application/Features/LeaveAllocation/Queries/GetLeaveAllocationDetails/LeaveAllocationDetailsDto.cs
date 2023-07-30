using HR.LeaveManagement.Application.Features.LeaveTypeFeature.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

//此處跟LeaveAllocationDto是一樣的，也可以選擇設置Common namespace, base detail 然後繼承;也可以像現在這樣，雖然重複，但實踐了單一職責
public class LeaveAllocationDetailsDto
{
    public int Id { get; set; }

    public int NumberOfDays { get; set; }

    public required LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }

    public int Period { get; set; }
}
