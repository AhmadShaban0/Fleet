using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace future_1_.Models
{
    public class Fleet
    { 
    public int FleetId { get; set; }
        [Required]
        public int fleetModel { get; set; }
        [Required]
        public string fleetType { get; set; }
        [Required]
        public int BoardNumber { get; set; }
        [Required]
        public int capacity { get; set; }
        public Region region { get; set; }
        [Required] 
        public int RegionId { get; set; }
        [Required]
        public string FleetState { get; set; }
        public TransportationEntity transportationEntity { get; set; }
        [Required]
        public int TransportationEntityId { get; set; }
        [Required] 
        public string effectiveness { get; set; }

        public DateTime CreationDate { get; set; }


        public Driver driver { get; set; }
        
        [Required]
        public int DriverId { get; set; }



        [Display(Name = "Front bus license")]
        public string FrontBus_license_PH { get; set; }
        [NotMapped]
        [Display(Name = "Front bus license")]
        [Required]
        public IFormFile FrontBus_license_File { get; set; }


        [Display(Name = "Back bus license")]
        public string BackBus_license_PH { get; set; }
        [NotMapped]
        [Display(Name = "Back bus license")]
        [Required]
        public IFormFile BackBus_license_File { get; set; }



        [Display(Name = "Authority Permit")]
        public string AuthorityPermit_PH { get; set; }
        [NotMapped]
        [Display(Name = "Authority Permit")]
        [Required]
        public IFormFile AuthorityPermit_File { get; set; }
        


    }
}
