using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR_LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR_LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _context.LeaveAllocations
            .AnyAsync(allocation => allocation.EmployeeId == userId
            && allocation.LeaveTypeId == leaveTypeId
            && allocation.Period == period);
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        List<LeaveAllocation>? leaveAllocations = await _context.LeaveAllocations
            .Include(allocation => allocation.LeaveType)
            .ToListAsync();

        return leaveAllocations;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        List<LeaveAllocation>? leaveAllocations = await _context.LeaveAllocations
            .Where(allocation => allocation.EmployeeId == userId)
            .Include(allocation => allocation.LeaveType)
            .ToListAsync();

        return leaveAllocations;
    }

    public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id)
    {
        LeaveAllocation? leaveAllocation = await _context.LeaveAllocations
            .Include(allocation => allocation.LeaveType)
            .FirstOrDefaultAsync(allocation => allocation.Id == id);

        return leaveAllocation;
    }

    public async Task<LeaveAllocation?> GetUserAllocations(string userId, int leaveTypeId)
    {
        LeaveAllocation? leaveAllocation = await _context.LeaveAllocations
            .FirstOrDefaultAsync(allocation => allocation.EmployeeId == userId
            && allocation.LeaveTypeId == leaveTypeId);

        return leaveAllocation;
    }
}
