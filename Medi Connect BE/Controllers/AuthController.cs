using Medi_Connect_BE.DataAccessLayer;
using Medi_Connect_BE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medi_Connect_BE.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthDL _authDL;
        public AuthController(IAuthDL authDL)
        {
            _authDL = authDL;
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationRequest request)
        {
            BasicResponse response = new BasicResponse();
            try {
                response = await _authDL.Registration(request); 
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInRequest request)
        {
            LogInResponse response = new LogInResponse();
            try
            {
                response = await _authDL.LogIn(request);    
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }
    }
}
