using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace future_1_.Models
{
    public class Region
    {   
        public int RegionId { get; set; }
        [Required]
        [Display(Name ="Arabic Name")]
        
        public string ArabicName { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string EnglishName { get; set; }
        [Display(Name = "Creation Date")]

        public DateTime CreationDate { get; set; }

    }
}
