namespace CustomerRegistration.Models
{
    public class CompanyFile(string fileName, string contentType, string data)
    {
        public  string FileName { get; set; } = fileName;
        public  string ContentType { get; set; } = contentType;
        public  string Data { get; set; } = data;
    }
}
