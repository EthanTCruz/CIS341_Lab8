using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel;
using static System.Formats.Asn1.AsnWriter;

namespace CIS_341_Lab06.Models
{
    public class Listing
    {
        public int ListingID { get; set; }
        public int CustomerID { get; set; }
        public int StoreID { get; set; } 
        public int ConditionID { get; set; } 

        
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Quantity")]
        public int Quantity { get; set; }



        [DisplayName("Customer")]
        public Customer Customer { get; set; }
        [DisplayName("Store")]
        public Store Store { get; set; }
        [DisplayName("Condition")]
        public Condition Condition { get; set; }
    }
}
