namespace MH.Domain.Configuration;

public class MailSettings
{
    public required string Sender { get; set; }
    public required string Title { get; set; }
    public required string SmtpServer { get; set; }
    public int Port { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public bool SSL { get; set; }
}