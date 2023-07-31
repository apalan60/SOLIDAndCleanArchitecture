using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Email;
using HR.LeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _appLogger;

    public UpdateLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository, 
        ILeaveTypeRepository leaveTypeRepository, 
        IMapper mapper, 
        IEmailSender emailSender,
        IAppLogger<UpdateLeaveRequestCommandHandler> appLogger)
    {
        this._leaveRequestRepository = leaveRequestRepository;
        this._leaveTypeRepository = leaveTypeRepository;
        this._mapper = mapper;
        this._emailSender = emailSender;
        this._appLogger = appLogger;
        this._appLogger = appLogger;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        await ValidateRequestAsync(request, leaveRequest);
        
        _mapper.Map(request, leaveRequest);
        await _leaveRequestRepository.UpdateAsync(leaveRequest!);

        await SendConfirmationEmail(request);

        return Unit.Value;
    }


    private async Task ValidateRequestAsync(UpdateLeaveRequestCommand request, Domain.LeaveRequest? leaveRequest)
    {
        if (leaveRequest == null) 
        {
            throw new NotFoundException(nameof(leaveRequest), request.Id);
        }

        var validator = new UpdateLeaveRequestCommandValidator(_leaveRequestRepository,_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Leave Request", validationResult);
    }

    private async Task SendConfirmationEmail(UpdateLeaveRequestCommand request)
    {
        try 
        {
            var email = new EmailMessage
            {
                To = string.Empty, /* Get email from employee record */
                Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
                $"has been updated successfully.",
                Subject = "Leave Request Updated"
            };

            await _emailSender.SendEmail(email);
        }

        catch(Exception ex)
        {
            _appLogger.LogWarning(ex.Message);
        }
    }

}
