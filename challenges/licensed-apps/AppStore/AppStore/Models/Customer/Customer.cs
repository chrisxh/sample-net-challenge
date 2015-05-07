using System;
using System.ComponentModel.DataAnnotations;

namespace AppStore.Models.Customer
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Display(Name = "Name")]
        [Required]
        [StringLength(200, ErrorMessage = "The Name may not exceed 200")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(200, ErrorMessage = "The Email may not exceed 200")]
        public string EmailAddress { get; set; }

        [Display(Name = "Customer Number")]
        [StringLength(150, ErrorMessage = "The Customer Number may not exceed 150")]
        public string Number { get; set; }

        public bool Active { get; set; }
    }
}