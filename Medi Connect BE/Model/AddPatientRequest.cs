namespace Medi_Connect_BE.Model
{
    public class AddPatientRequest
    {
        public int DoctorUserID { get; set; }
        public int PatientUserID { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCity { get; set; }
        public string? Description { get; set; }
        public string? AppointmentDate { get; set; }
        public string? AppointmentTime { get; set; }
    }
}
