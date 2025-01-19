namespace CustomerRegistrationApi.Request
{
    public class CompanyFileRequest
    {        
        public required string FileName { get; set; }
        public required string ContentType { get; set; }
        public required string Data { get; set; }
    }
}
