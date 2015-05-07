using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppStore.Models.Licenses
{
    public class License
    {
        public int Id { get; set; }

        [Display(Name = "Number")]
        [Required]
        [StringLength(250, ErrorMessage = "The Name may not exceed 250")]
        public string Number { get; set; }

        [Display(Name = "Active Date")]
        [Required]
        [DataType(DataType.Date)]
        public string ActiveDate { get; set; }

        [Display(Name = "DeActive Date")]
        [Required]
        [DataType(DataType.Date)]
        public string DeActiveDate { get; set; }

        public bool Active { get; set; }
    }
}