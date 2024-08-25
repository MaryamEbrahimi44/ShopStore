namespace Application.Dto
{
    public class RequestSaveVisitorInfoDto
    {
        public string Id { get; set; }
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string RefferLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PhysicalPath { get; set; }
        public VisitorVersionDto Browser { get; set; }
        public VisitorVersionDto OperationSystem { get; set; }
        public DeviceDto Device { get; set; }
        public DateTime Time { get; set; }
        public string VisitorId { get; set; }
    }
}
