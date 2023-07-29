using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypeFeature.Queries.GetAllLeaveTypes;

public record GetLeaveTypeQuery : IRequest<List<LeaveTypeDto>>;

//<T> : data type expected to return  => equal to IRequestHandler Response type
