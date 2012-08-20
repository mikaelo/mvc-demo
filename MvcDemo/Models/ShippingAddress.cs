using System.ComponentModel.DataAnnotations;
using MvcDemo.Annotations;

namespace MvcDemo.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Checksum(6,ErrorMessage = "Wrong checksum")]
        public string Index { get; set; }
    }
}