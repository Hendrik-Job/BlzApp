using System.ComponentModel.DataAnnotations;

namespace BlzApp.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required]
        public string AddressCode { get; set; }
        [Required]
        public string AddressName { get; set; }        
    }
}
