namespace Medi_Connect_BE.Model
{
    public class RegistrationRequest
    {
        //Name, EmailID, City, Specialization, Password, ConfirmPassword
        //EmailID, Password
        public string? Name { get; set; } 
        public string? EmailID { get; set; } 
        public string? City { get; set; } 
        public string? Specialization { get; set; } 
        public string? Password { get; set; } 
       public string? Role { get; set; }
    }

    public class BasicResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
