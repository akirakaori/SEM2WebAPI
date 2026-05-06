namespace SEM2WebAPI.Dtos.Response
{
    public class Loginresponse // this is the response that will be sent back to the client after a login attempt. It contains information about whether the login was successful, any messages (like error messages), and a token if the login was successful.
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
}