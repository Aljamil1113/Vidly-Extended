using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Discount Rate %")]
        public int? DiscountRate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Is Delinquent")]
        public bool IsDelinquent { get; set; }

        [Display(Name = "Rent Limit")]
        public byte RentLimit { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}