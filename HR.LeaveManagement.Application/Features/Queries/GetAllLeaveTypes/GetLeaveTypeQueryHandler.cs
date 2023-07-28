using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.Queries.GetAllLeaveTypes;

/// <summary>
/// 接收Request傳來的物件，並傳回Request期望的Response Type
/// </summary>
public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<LeaveType>? leaveTypes = await _leaveTypeRepository.GetAsync();

        List<LeaveTypeDto>? leaveTypeDtos = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
            
        return leaveTypeDtos;
    }
}
