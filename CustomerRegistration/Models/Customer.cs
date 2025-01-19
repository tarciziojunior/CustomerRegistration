namespace CustomerRegistration.Models
{
    public class Customer(string name, string email, IList<string> addresses, CompanyFile companyFile)
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public IList<string> Addresses { get; set; } = addresses;
        public CompanyFile CompanyFile { get; set; } = companyFile;
    }

}


