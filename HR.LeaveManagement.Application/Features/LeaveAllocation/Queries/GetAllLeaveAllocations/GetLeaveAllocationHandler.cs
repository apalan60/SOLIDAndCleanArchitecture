using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;


namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;

public class GetLeaveAllocationHandler : IRequestHandler<GetLeaveAllocationQuery, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        this._leaveAllocationRepository = leaveAllocationRepository;
        this._mapper = mapper;
    }
    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationQuery request, CancellationToken cancellationToken)
    {
        //Todo
        //GetRecord for specific user
        //Get Allocation per employee 
        var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
        var leaveAllocationsDtos = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
        return leaveAllocationsDtos;
    }
}
