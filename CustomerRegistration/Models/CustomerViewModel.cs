namespace CustomerRegistration.Models
{
    public class CustomerViewModel
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required IList<string> Addresses { get; set; }
        public required IFormFile Logo { get; set; }        

    }
}


