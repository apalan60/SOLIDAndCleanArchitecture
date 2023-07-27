using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Persistence.DatabaseContext;

public class HrDatabaseContext : DbContext
{
    public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options) : base(options)
    {
        
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
    {
        foreach (var baseEntityEntry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified)) 
        {
            baseEntityEntry.Entity.DateModified = DateTime.Now;
            
            if (baseEntityEntry.State == EntityState.Added) 
            {
                baseEntityEntry.Entity.DateCreated = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
