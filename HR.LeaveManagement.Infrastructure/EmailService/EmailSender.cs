using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Models.EMail;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace HR.LeaveManagement.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    public EmailSettings EmailSettings { get; }
    
    //inject 
    //Options.IOptions<T>與Configuration.IConfiguration的差異 => 前者為強型別，需自訂物件; 後者適用較不易變動的設定，因為如果變動了需大量更改程式碼
    public EmailSender(IOptions<EmailSettings> emailSettings)  
    {
        EmailSettings = emailSettings.Value;
    }

    public async Task<bool> SendEmail(EMailMessage email)
    {
        var client = new SendGridClient(EmailSettings.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress
        {
            Email = EmailSettings.FromAddress,
            Name = EmailSettings.FromName
        };

        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(message);

        return response.IsSuccessStatusCode;
    }
}
