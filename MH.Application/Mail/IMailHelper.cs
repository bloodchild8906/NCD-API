﻿namespace MH.Application.Mail;

public interface IMailHelper
{
    Task SendEmail(string sendTo, string subject, string body);
}