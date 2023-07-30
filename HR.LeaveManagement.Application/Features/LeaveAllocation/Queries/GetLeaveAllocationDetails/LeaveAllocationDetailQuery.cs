using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public record LeaveAllocationDetailQuery(int Id) : IRequest<LeaveAllocationDetailsDto>;
