using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppStore.Models.Apps
{
    public class Application
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        [StringLength(250, ErrorMessage = "The Name may not exceed 250")]
        public string Title { get; set; }

        [Display(Name = "Icon")]
        [StringLength(150, ErrorMessage = "The Name may not exceed 150")]
        public string Icon { get; set; }

        public bool Active { get; set; }
    }
}