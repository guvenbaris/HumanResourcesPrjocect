namespace Entities.Concrete
{
    public class Address :IEntity
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public bool Statement { get; set; }
    }
}