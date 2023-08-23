using E_Commerce_web_api.Data;
using Medi_Connect_BE.Data;
using Medi_Connect_BE.Model;
using Microsoft.EntityFrameworkCore;

namespace Medi_Connect_BE.DataAccessLayer
{
    public class AuthDL : IAuthDL
    {

        private readonly ApplicationDBContext _dBContext;
        public AuthDL(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<LogInResponse> LogIn(LogInRequest request)
        {
            LogInResponse response = new LogInResponse();
            response.IsSuccess = true;
            response.Message = "Registration Successfully";
            try
            {
                var IsUserExist = _dBContext
                    .UserDetails
                    .FirstOrDefault(x => x.EmailID.ToLower() == request.EmailID.ToLower()
                    && x.Password == request.Password);

                if(IsUserExist == null)
                {
                    response.IsSuccess = false;
                    response.Message = "User Not Exist";
                    return response;
                }

                IsUserExist.Password = null;
                response.data = new UserDetails();
                response.data = IsUserExist;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BasicResponse> Registration(RegistrationRequest request)
        {
            BasicResponse response = new BasicResponse();
            response.IsSuccess = true;
            response.Message = "Registration Successfully";
            try
            {

                var IsUserFound = _dBContext
                    .UserDetails
                    .FirstOrDefault(x => x.EmailID.ToLower() == request.EmailID.ToLower());

                if (IsUserFound != null)
                {
                    response.IsSuccess = false;
                    response.Message = "User Already Exist";
                    return response;
                }

                /*
                public string? InsertionDate { get; set; }
                public string? EmailID { get; set; }
                public string? City { get; set; }
                public string? Specialization { get; set; }
                public string? Password { get; set; }
                public bool IsActive { get; set; }
                */

                UserDetails _data = new UserDetails();
                _data.InsertionDate = DateTime.Now.ToString("dd-MM-yyyy");
                _data.Name = request.Name;
                _data.EmailID = request.EmailID;
                _data.City = request.City;
                _data.Specialization = request.Specialization;
                _data.Password = request.Password;
                _data.Role = request.Role;
                _data.IsActive = true;

                await _dBContext.AddAsync(_data);
                await _dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
