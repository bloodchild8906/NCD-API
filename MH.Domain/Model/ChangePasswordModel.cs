﻿namespace MH.Domain.Model;

public class ChangePasswordModel
{
    public int UserId { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}