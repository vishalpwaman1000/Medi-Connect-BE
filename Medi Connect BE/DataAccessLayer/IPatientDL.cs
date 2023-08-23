using Medi_Connect_BE.Model;

namespace Medi_Connect_BE.DataAccessLayer
{
    public interface IPatientDL
    {
        Task<GetAllCityAndSpecializationListResponse> GetAllCityAndSpecializationList();
    }
}
