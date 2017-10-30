using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubcribeToNewsletter { get; set; }
        
        public byte MembershipTypeId { get; set; }

        //[CustomerBirthdayValidation]
        public DateTime? birthDate { get; set; }

    }
}