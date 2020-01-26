using System;
using System.ComponentModel.DataAnnotations;

namespace StreamDream.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //[/*Min18YearsIfMember]*/
        public byte MembershipTypeId { get; set; }
    }
}