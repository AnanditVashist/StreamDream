using StreamDream.Models;
using System.Collections.Generic;

namespace StreamDream.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> membershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}