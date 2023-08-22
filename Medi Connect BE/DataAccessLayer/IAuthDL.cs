using Medi_Connect_BE.Model;

namespace Medi_Connect_BE.DataAccessLayer
{
    public interface IAuthDL
    {
        Task<BasicResponse> Registration(RegistrationRequest request);
        Task<LogInResponse> LogIn(LogInRequest request);
    }
}
