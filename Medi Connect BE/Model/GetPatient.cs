using Medi_Connect_BE.Data;

namespace Medi_Connect_BE.Model
{
    public class GetPatientResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<GetPatient>? data { get; set; }
    }

    public class GetPatient
    {
        public int Id { get; set; }
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
        public string? Status { get; set; }
    }
}
