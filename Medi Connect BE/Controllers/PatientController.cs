using Medi_Connect_BE.DataAccessLayer;
using Medi_Connect_BE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medi_Connect_BE.Controllers
{
    [Route("api/[controller]/[Action]")]
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

        [HttpPost]
        public async Task<IActionResult> AddPatient(AddPatientRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                response = await _patientDL.AddPatient(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPatient(GetPatientRequest request)
        {
            GetPatientResponse response = new GetPatientResponse();
            try
            {
                response = await _patientDL.GetPatient(request);
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
