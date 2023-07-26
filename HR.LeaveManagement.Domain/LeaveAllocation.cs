using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveAllocation
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }

    public LeaveType? LeaveType { get; set; }
    public int LeaveTyped { get; set; }

    public int Period { get; set; }
}
public class LeaveRequest : BaseEntity
{
    public DateTime StartDate{ get; set;}
    public DateTime EndDate { get; set; }

    public LeaveType? LeaveType { get; set; }

    public int LeaveTypeId { get; set; }
    public string? RequestComments { get; set; }

    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public string RequestingEmployeId { get; set; } = string.Empty;
}