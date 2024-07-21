namespace ProductRequestsAPI.Models
{
    using System.Collections.Generic;

    public class Request
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
        public bool IsApproved { get; set; }
    }
}
