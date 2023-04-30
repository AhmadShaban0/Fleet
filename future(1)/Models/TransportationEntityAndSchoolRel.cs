using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace future_1_.Models
{
    public class TransportationEntityAndSchoolRel
    {
        public School school { get; set; }
        [Required]
        public int SchoolId { get; set; }

        public TransportationEntity transportationEntity { get; set; }
        [Required] 
        public int TransportationEntityId { get; set; }

    }
}
