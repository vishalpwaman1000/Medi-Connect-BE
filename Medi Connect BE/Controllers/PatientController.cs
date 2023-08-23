using Medi_Connect_BE.DataAccessLayer;
using Medi_Connect_BE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medi_Connect_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientDL _patientDL;
        public PatientController(IPatientDL patientDL)
        {
            _patientDL = patientDL;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCityAndSpecializationList()
        {
            GetAllCityAndSpecializationListResponse response = new GetAllCityAndSpecializationListResponse();
            try
            {
                response = await _patientDL.GetAllCityAndSpecializationList();
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
