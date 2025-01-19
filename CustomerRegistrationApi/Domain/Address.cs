namespace CustomerRegistrationApi.Domain
{
    public class Address(string street)
    {
        public string Street { get; set; } = street;
        public int? Id { get; internal set; }
    }
}
