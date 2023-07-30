using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveTypeFeature.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypeFeature.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypeFeature.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveTypeFeature.Queries.GetLeaveTypeDetail;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfile;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap(); //類別有需要往回轉型時添加，此處為示範
        
        CreateMap<LeaveType, LeaveTypeDetailsDto>();
        
        CreateMap<CreateLeaveTypeCommand, LeaveType>();

        CreateMap<UpdateLeaveTypeCommand, LeaveType>();
    }
}
