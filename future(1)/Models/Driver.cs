using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace future_1_.Models
{
    public class Driver
    {
  
        [Key]
        public int DriverId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

       // [DataType(DataType.Password)]
       // [Compare("password",ErrorMessage = "The password and confirmation password do not match.")]
       // public string ConfirmPassword { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AccessNumber { get; set; }
        [Required]
        public string State { get; set; }
        
        public DateTime CreationDate { get; set; }

        public TransportationEntity trEntity { get; set; }
        [Required]
        public int TransportationEntityId { get; set; }



        public Fleet fleet { get; set; }
        // public int FleetId { get; set; }



        // photo prop    PH => photo

        [Display(Name = "ID Photo PH")]
        public string IDPhoto { get; set; }
        [Required]
        [NotMapped]
        [Display(Name = "ID Photo File")]
        public IFormFile IdPhoto_File { get; set; }

        
        
        
        
        [Display(Name = "Driver license PH")]
        public string DriverLicense_PH { get; set; }
        [Required]
        [NotMapped]
        [Display(Name = "Driver license File")]
        public IFormFile DriverLicense_File { get; set; }





        [Display(Name = "Disease-Free-Cert PH")]
        public string DiseaseFreeCert_PH { get; set; }
        [Required]
        [NotMapped]
        [Display(Name = "Disease-Free-Cert File")]
        public IFormFile DiseaseFreeCert_File { get; set; }




        [Display(Name = "Non-Conviction-Cert PH")]
        public string NonConvictionCert_PH { get; set; }
        [Required]
        [NotMapped]
        [Display(Name = "Non-Conviction-Cert File")]
        public IFormFile NonConvictionCert_File { get; set; }





        [Display(Name = "SecurityPermit PH")]
        public string SecurityPermit_PH { get; set; }
        [Required]
        [NotMapped]
        [Display(Name = "SecurityPermit File")]
        public IFormFile SecurityPermit_File { get; set; }




        [Display(Name = "PersonalPhoto PH")]
        public string PersonalPhoto { get; set; }
        [Required]
        [NotMapped]
        [Display(Name = "PersonalPhoto File")]
        public IFormFile PersonalPhoto_File { get; set; }




        

    }
}
