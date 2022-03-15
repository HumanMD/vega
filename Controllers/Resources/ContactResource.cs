using System.ComponentModel.DataAnnotations;

namespace vega.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [StringLength(200)]
        public string Phone { get; set; }
    }
}