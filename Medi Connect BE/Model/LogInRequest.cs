using Medi_Connect_BE.Data;

namespace Medi_Connect_BE.Model
{
    public class LogInRequest
    {
        public string? EmailID { get; set; }
        public string? Password { get; set; }
    }

    public class LogInResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public UserDetails data { get; set; }
    }
}
