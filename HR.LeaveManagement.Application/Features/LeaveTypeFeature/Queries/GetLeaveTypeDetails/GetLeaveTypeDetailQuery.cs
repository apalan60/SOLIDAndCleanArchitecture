﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypeFeature.Queries.GetLeaveTypeDetail;

public record GetLeaveTypeDetailQuery(int Id) : IRequest<LeaveTypeDetailsDto>;
