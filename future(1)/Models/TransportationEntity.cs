using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace future_1_.Models
{
    public class TransportationEntity
    {
  

        public int TransportationEntityId { get; set; }
        [Required]
        public string ArabicName { get; set; }
        [Required]
        public string EnglishName { get; set; }
        [Required]
        public string website { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string CompanyType { get; set; }

        public DateTime CreationDate { get; set; }

        public Region Region { get; set; }
        [Required]
        public int RegionId { get; set; }

        public ICollection<School> schools { get; set; }

        public IList<TransportationEntityAndSchoolRel> transportationEntityAndSchoolRels { get; set; } 
        public IList<Fleet> fleets { get; set; }



        [Display(Name ="Logo Name")]
        public string LogoName { get; set; }
        [Required]
        [NotMapped]
        [Display(Name="Logo File")]
        public IFormFile LogoFile { get; set; }

    }
} 
