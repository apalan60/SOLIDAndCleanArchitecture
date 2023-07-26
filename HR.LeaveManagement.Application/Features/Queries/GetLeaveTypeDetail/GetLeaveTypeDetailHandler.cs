using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.Queries.GetLeaveTypeDetail;

public class GetLeaveTypeDetailHandler : IRequestHandler<GetLeaveTypeDetailQuery, LeaveTypeDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeDetailHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailQuery request, CancellationToken cancellationToken)
    {
        LeaveType leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

        LeaveTypeDetailsDto leaveTypeDetailDto = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

        return leaveTypeDetailDto;
    }
}
