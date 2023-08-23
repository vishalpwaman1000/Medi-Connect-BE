using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medi_Connect_BE.Data
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? InsertionDate { get; set; }
        public string? Name { get; set; }
        public string? EmailID { get; set; }
        public string? City { get; set; }
        public string? Specialization { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public bool IsActive { get; set; }

    }

    public class PatientDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string InsertionDate { get; set; } = DateTime.Now.ToString("dd-MM-yyyy");
        public int PatientUserID { get; set; }
        public int DoctorUserID { get; set; } 
        public string? PatientName { get; set; }
        public string? PatientCity { get; set; }
        public string? Description { get; set; }
        public string? AppointmentDate { get; set; }
        public string? AppointmentTime { get; set; }
        public string? Status { get; set; }
    }
}
