namespace Day9Lab2.Models {
    public class Customer {
        public int ID { get; set; }
        public string VAT { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlacklisted { get; set; }
        public string PictureName { get; set; }

        public Customer() {
            VAT = FullName = Email = Phone = Address = City = PostalCode = Country = string.Empty;
            IsActive = true;
            IsBlacklisted=false;
        }
    }
}
