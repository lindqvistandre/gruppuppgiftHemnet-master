using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace gruppuppgiftHemnet.Models
{
    public class Listing
    {

        //[Key]
        //public Guid Listing_Id { get; set; }
        
        //public string Listing_Type { get; set; }
        
        //public string Address { get; set; }
        
        //public int Room_Count { get; set; }
        
        //public int Listing_Price { get; set; }

        //public string Description { get; set; }
        
        //public int Year_Built { get; set; }

        //public DateTime Tour_Date { get; set; }
        
        //public int Floor_Area { get; set; }
        
        //public int Nonusable_Floor_Area { get; set; }
        
        //public int Lot_Area { get; set; }
        
        //public string Form_Of_Lease { get; set; }
        //public Guid Broker_Id { get; set; } //Broker_Id.

        ////NavProps:
        //public ICollection<Image> Images { get; set; }


        [Key]
        public Guid Listing_Id { get; set; }
        [Required]
        public string Listing_Type { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Postal_Code { get; set; }
        [Required]
        public string Postal_Area { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        [Required]
        public int Room_Count { get; set; }
        [Required]
        public int Listing_Price { get; set; }

        public string Description { get; set; }
        [Required]
        public int Year_Built { get; set; }

        public DateTime Tour_Date { get; set; }
        [Required]
        public int Floor_Area { get; set; }
        [Required]
        public int Nonusable_Floor_Area { get; set; }
        [Required]
        public int Lot_Area { get; set; }
        [Required]
        public string Form_Of_Lease { get; set; }
        public Guid Broker_Id { get; set; } //Broker_Id.

        //NavProps:

        public virtual ICollection<Image> Images { get; set; }


    }
}