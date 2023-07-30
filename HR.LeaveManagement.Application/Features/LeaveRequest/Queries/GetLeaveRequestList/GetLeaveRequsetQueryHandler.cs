using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;

public class GetLeaveRequsetQueryHandler : IRequestHandler<GetLeaveRequsetQuery, List<LeaveRequestDto>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequsetQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._mapper = mapper;
    }

    public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequsetQuery request, CancellationToken cancellationToken)
    {
        List<Domain.LeaveRequest> leaaveRequest = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
        List<LeaveRequestDto> response = _mapper.Map<List<LeaveRequestDto>>(leaaveRequest);
        return response;
    }
}
