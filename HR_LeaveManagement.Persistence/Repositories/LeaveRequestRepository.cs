using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR_LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HR_LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        List<LeaveRequest>? leaveRequest = await _context.LeaveRequests
            .Include(request => request.LeaveType)
            .ToListAsync();

        return leaveRequest;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
    {
        List<LeaveRequest> leaveRequest = await _context.LeaveRequests
            .Where(request => request.RequestingEmployeId == userId)
            .Include(request => request.LeaveType)
            .ToListAsync();

        return leaveRequest;
    }

    public async Task<LeaveRequest?> GetLeaveRequestWithDetails(int id)
    {
        LeaveRequest? leaveRequest = await _context.LeaveRequests
            .Include(request => request.LeaveType)
            .FirstOrDefaultAsync(request => request.Id == id);

        return leaveRequest;
    }
}
