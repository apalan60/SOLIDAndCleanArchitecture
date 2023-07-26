using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts;

public interface IGenericRepository<T> where T : class  //deifine T is a class 
{
    Task<T> GetAsync();

    Task<T> GetByIdAsync(int id);
    
    Task<T> CreateAsync(T entity);
    
    Task<T> UpdateAsync(T entity);
    
    Task DeleteAsync(T entity);
    
}

public interface ILeaveTypeRepository : IGenericRepository<LeaveType> 
{
    
}
public interface ILeaveAllocationRepository : IGenericRepository<LeaveType>
{

}
public interface ILeaveRequestRepository : IGenericRepository<LeaveType>
{

}
