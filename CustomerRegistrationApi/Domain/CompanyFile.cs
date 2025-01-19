namespace CustomerRegistrationApi.Domain
{
    public class CompanyFile
    {
        public CompanyFile()
        {

        }

        public CompanyFile(string fileName, string contentType, string data)
        {
            FileName = fileName;
            ContentType = contentType;
            Data = data;
        }

        public string FileName { get;  }
        public string ContentType { get;  } 
        public string Data { get; }
        public int? Id { get; internal set; }
    }
}
