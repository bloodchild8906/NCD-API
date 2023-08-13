using MH.Domain.Model;
using MH.Domain.Configuration;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace MH.Application.Mail;

public class MailHelper : IMailHelper
{
    private readonly MailSettings _settings;

    public MailHelper(MailSettings settings)
        => _settings = settings;

    private static MimeMessage CreateMimeMessageFromEmailMessage(EmailMessageModel message)
        => new()
        {
            Sender = message.Sender,
            To = { message.Reciever },
            Subject = message.Subject,
            Body = new BodyBuilder { HtmlBody = message.Content }.ToMessageBody()
        };

    //Note: this has no business logging that should be done by an interceptor
    public async Task SendEmail(string sendTo, string subject, string body)
    {
        await Task.Run(() =>
        {
            var mailMsg = new EmailMessageModel
            {
                Sender = new MailboxAddress(_settings.Title, _settings.Sender),
                Reciever = new MailboxAddress(_settings.Title, sendTo),
                Subject = subject,
                Content = body
            };
            var mimeMessage = Task.Run(() => CreateMimeMessageFromEmailMessage(mailMsg)).Result;

            using (var client = new SmtpClient())
            {
                client.Connect(_settings.SmtpServer, _settings.Port);
                client.Authenticate(_settings.UserName, _settings.Password);
                client.Send(mimeMessage);
                client.Disconnect(true);
            }

            return Task.CompletedTask;
        });
    }
}