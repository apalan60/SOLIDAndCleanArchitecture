using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)   
    =>   this._leaveTypeRepository = leaveTypeRepository;
    

    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        //get entity by id
        LeaveType leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
        // verify

        //void delete 
        await _leaveTypeRepository.DeleteAsync(leaveType);
        return Unit.Value;
    }
}
