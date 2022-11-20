using System.ComponentModel;

namespace CIS_341_Lab06.Models
{
    public class Condition
    {
        [DisplayName("Codnition ID")]
        public int ConditionID { get; set; } // PK
        [DisplayName("Description")]
        public string Description { get; set; }

        public ICollection<Listing> ListingsByCollection { get; set; }
    }
}
