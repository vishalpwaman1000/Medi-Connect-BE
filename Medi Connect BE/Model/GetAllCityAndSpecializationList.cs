namespace Medi_Connect_BE.Model
{
    public class GetAllCityAndSpecializationListResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<string>? city { get; set; }
        public List<string>? specialization { get; set; }
    }
}
