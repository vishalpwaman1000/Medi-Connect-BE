using Medi_Connect_BE.Model;

namespace Medi_Connect_BE.DataAccessLayer
{
    public interface IPatientDL
    {
        Task<GetAllCityAndSpecializationListResponse> GetAllCityAndSpecializationList();
        Task<BasicResponse> AddPatient(AddPatientRequest request);
        Task<GetPatientResponse> GetPatient(GetPatientRequest request);
    }
}
