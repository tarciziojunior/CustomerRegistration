namespace CustomerRegistrationApi.Request.Customer
{
    public class CustomerRequest
    {
        /// <summary>
        /// Customer's full name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Customer's email address (must be unique).
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// List of customer's addresses.
        /// </summary>
        public required List<String> Addresses { get; set; }

        /// <summary>
        /// Logo file path or base64 representation for upload.
        /// </summary>
        public required CompanyFileRequest CompanyFile { get; set; }
        // Método estático para conversão de CustomerRequest para Customer
       
    }
}
