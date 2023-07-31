using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Email;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public ChangeLeaveRequestApprovalCommandHandler(
        IMapper mapper,
        IEmailSender emailSender,
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._emailSender = emailSender;
        this._leaveRequestRepository = leaveRequestRepository;
        this._leaveTypeRepository = leaveTypeRepository;
    }


    public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
        await UpdateLeaveRequestApprovalStatus(request, leaveRequest);
        await SendConfirmEmail(leaveRequest);
        return Unit.Value;
    }

    private async Task SendConfirmEmail(Domain.LeaveRequest? leaveRequest)
    {
        try
        {
            var email = new EmailMessage
            {
                To = string.Empty, /* Get email from employee record */
                Body = $"The approval status for your leave request for {leaveRequest!.StartDate:D} to {leaveRequest.EndDate:D} has been updated.",
                Subject = "Leave Request Approval Status Updated"
            };
            await _emailSender.SendEmail(email);
        }
        catch (Exception)
        {
            // log error
        }
    }

    private async Task UpdateLeaveRequestApprovalStatus(ChangeLeaveRequestApprovalCommand request, Domain.LeaveRequest? leaveRequest)
    {
        if (leaveRequest == null)
        {
            throw new NotFoundException(nameof(request), request.Id);
        }
        leaveRequest.Approved = true;
        await _leaveRequestRepository.UpdateAsync(leaveRequest);
    }
}