namespace CustomerRegistration.Models
{
    public class CustomerIndexViewModel
    {
        public CustomerIndexViewModel(string name, string email, IList<string> addresses, string base64Image)
        {
            Name = name;
            Email = email;
            Addresses = addresses;
            Base64Image = base64Image;
        }

        public CustomerIndexViewModel()
        {
            Name = string.Empty;
            Email = string.Empty; ;
            Addresses = null;
            Base64Image = string.Empty; 
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public IList<string>? Addresses { get; set; }
        public string Base64Image { get; set; }

    }
}


