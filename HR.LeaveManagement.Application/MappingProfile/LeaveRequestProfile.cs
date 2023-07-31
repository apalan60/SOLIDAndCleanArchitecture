using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfile;

public class LeaveRequestProfile : Profile
{
    public LeaveRequestProfile()
    {
        CreateMap<LeaveRequestDto, LeaveRequest>().ReverseMap();

        CreateMap<LeaveRequest, LeaveRequestDetailsDto>().ReverseMap();

        CreateMap<CreateLeaveRequestCommand, LeaveRequest>();

        CreateMap<UpdateLeaveRequestCommand, LeaveRequest>();
    }
}
