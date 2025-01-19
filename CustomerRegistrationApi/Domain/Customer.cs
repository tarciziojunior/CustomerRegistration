using System.IO;

namespace CustomerRegistrationApi.Domain
{
    public class Customer
    {
        // Construtor público sem parâmetros
        public Customer() { }

        public Customer(string name, string email, List<Address> addresses, CompanyFile companyFile, int? id)
        {
            Name = name;
            Email = email;
            Addresses = addresses;
            CompanyFile = companyFile;
            Id = id;
        }

        public string Name { get; set; }

        /// <summary>
        /// Customer's email address (must be unique).
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// List of customer's addresses.
        /// </summary>
        public List<Address> Addresses { get; set; }

        /// <summary>
        /// Logo file path or base64 representation for upload.
        /// </summary>
        public CompanyFile CompanyFile { get; set; }
        public int? Id { get; internal set; }
    }
}
