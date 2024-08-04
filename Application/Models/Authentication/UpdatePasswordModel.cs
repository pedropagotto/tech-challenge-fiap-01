namespace Application.Models.Authentication;

public class UpdatePasswordModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Hash { get; set; }
}