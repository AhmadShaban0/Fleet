using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace future_1_.Models
{
    public class School
    {
     //   public enum type { Private,Public}

        public int SchoolId { get; set; }
        [Required]
        public string ArabicName { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [Required]
        public string SchoolType { get; set; } 
        public DateTime CreationDate { get; set; }

        public Region Region { get; set; }
        [Required]
        public int RegionId { get; set; }

        public ICollection<TransportationEntity> transportationEntities { get; set; }
        public IList<TransportationEntityAndSchoolRel> transportationEntityAndSchoolRels { get; set; }


        
        [Display(Name = "Logo Name")]
        public string LogoName { get; set; }

        [NotMapped]
        [Display(Name = "Logo File")]
        [Required]
        public IFormFile LogoFile { get; set; }
    }
}
