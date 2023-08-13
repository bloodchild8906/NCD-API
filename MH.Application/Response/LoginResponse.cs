namespace MH.Application.Response;

public class LoginResponse
{
    public int Id { get; init; }
    public string? Token { get; init; }
    public string? Email { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public List<string>? Role { get; init; }
}