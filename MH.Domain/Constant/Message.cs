namespace MH.Domain.Constant;

public static class Message
{
    //Authentication
    public const string UserRegistrationSuccess = "Successflly Registered";
    public const string UserRegistrationFailed = "Failed to register User";
    //OTP
    public const string OtpVerified = "OTP verified";
    public const string OtpExpired = "OTP expired";
    public const string OtpVerificationFailed = "Failed to verify OTP";
    //Throw Exception
    public const string RecordNotFound = "Record not found";
    //User Related
    public const string UserIdCannotBeNull = "User id cannot be null.";
    public const string EmailNotFound = "Email not found";
}