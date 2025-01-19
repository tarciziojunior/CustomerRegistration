namespace CustomerRegistration.Models
{
    public class CustomerEditModel
    {
        public CustomerEditModel(string name, string email, IList<string> addresses, string base64Image, string contentType, string fileName)
        {
            Name = name;
            Email = email;
            Addresses = addresses;
            Base64Image = base64Image;
            ContentType = contentType;
            FileName = fileName;
            Data = string.Empty;
            Logo = null;
        }

        public CustomerEditModel()
        {
            Name = string.Empty;
            Email = string.Empty;
            Addresses = [];
            Base64Image = string.Empty; 
            ContentType = string.Empty; 
            FileName = string.Empty; 
            Data = string.Empty;
            Logo = null;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public IList<string> Addresses { get; set; }
        public string Base64Image { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string Data { get; set; }
        public IFormFile? Logo { get; set; }

    }
}


