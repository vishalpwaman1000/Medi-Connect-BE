using E_Commerce_web_api.Data;
using Medi_Connect_BE.Data;
using Medi_Connect_BE.Model;
using Microsoft.EntityFrameworkCore;

namespace Medi_Connect_BE.DataAccessLayer
{
    public class PatientDL : IPatientDL
    {
        private readonly ApplicationDBContext _dBContext;
        public PatientDL(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<BasicResponse> AddPatient(AddPatientRequest request)
        {
            BasicResponse response = new BasicResponse();
            try
            {
                PatientDetails _data = new PatientDetails()
                {
                    InsertionDate = DateTime.Now.ToString("dd-MM-yyyy"),
                    DoctorUserID = request.DoctorUserID,
                    PatientUserID = request.PatientUserID,
                    PatientName = request.PatientName,
                    PatientCity = request.PatientCity,
                    Description = request.Description,
                    AppointmentDate = request.AppointmentDate,
                    AppointmentTime = request.AppointmentTime,
                    Status = "Pending"
                };

                await _dBContext.AddAsync(_data);
                await _dBContext.SaveChangesAsync();

            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return response;
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

        public async Task<GetPatientResponse> GetPatient(GetPatientRequest request)
        {
            GetPatientResponse response = new GetPatientResponse();
            try
            {

                var _patientDataList = (from _data in _dBContext.PatientDetails
                                 where _data.PatientUserID==request.PatientID
                                 select _data)
                                 .Skip((request.PageNumber-1)*request.PageSize)
                                 .Take(request.PageSize)
                                 .ToList();

                if (_patientDataList.Count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Patient Record Not Found";
                    return response;
                }

/*                public int Id { get; set; }
        public string? InsertionDate { get; set; }
        public int PatientUserID { get; set; }
        public int DoctorUserID { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorCity { get; set; }
        public string? DoctorSpecialization { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCity { get; set; }
        public string? Description { get; set; }
        public string? AppointmentDate { get; set; }
        public string? AppointmentTime { get; set; }
        public string? Status { get; set; }*/

        _patientDataList.ForEach(async x =>
                {
                    GetPatient _data = new GetPatient();
                    _data.Id = x.Id;
                    _data.InsertionDate = x.InsertionDate;
                    _data.PatientUserID = x.PatientUserID;
                    var _doctorData = await (from _user in _dBContext.UserDetails
                                     where _user.Id == _data.DoctorUserID
                                     select _user).FirstOrDefaultAsync();
                    _data.DoctorUserID = x.DoctorUserID;
                    _data.DoctorName = _doctorData.EmailID;

                });
                
            }catch  (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : "+ ex.Message;
            }

            return response;
        }
    }
}
