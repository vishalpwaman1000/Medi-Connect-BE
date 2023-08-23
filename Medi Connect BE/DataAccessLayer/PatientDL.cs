using E_Commerce_web_api.Data;
using Medi_Connect_BE.Model;

namespace Medi_Connect_BE.DataAccessLayer
{
    public class PatientDL : IPatientDL
    {
        private readonly ApplicationDBContext _dBContext;
        public PatientDL(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<GetAllCityAndSpecializationListResponse> GetAllCityAndSpecializationList()
        {
            GetAllCityAndSpecializationListResponse response = new GetAllCityAndSpecializationListResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            response.city = new List<string>();
            response.specialization = new List<string>();
            try
            {

                response.city = (from _data in _dBContext.UserDetails
                                 where _data.Role.ToLower()=="doctor" && !String.IsNullOrEmpty(_data.City)
                                 select _data.City.Trim()).Distinct().ToList();

                response.specialization = (from _data in _dBContext.UserDetails
                                           where _data.Role.ToLower() == "doctor" && !String.IsNullOrEmpty(_data.City)
                                           select _data.Specialization.Trim()).Distinct().ToList();

            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
