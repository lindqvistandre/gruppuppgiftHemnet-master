using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gruppuppgiftHemnet.Models.DTO
{
    public class SubscriptionDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Listing_Id { get; set; }
    }
}
