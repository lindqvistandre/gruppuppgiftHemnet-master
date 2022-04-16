using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gruppuppgiftHemnet.Models
{
    public class Image
    {
        //Kanske inte behövs
        
        [Key]
        public Guid Image_Id { get; set; }
        
        public string Image_url { get; set; }
        public Guid Listing_Id { get; set; }

        public Listing Listing { get; set; } //Navprop

    }
}