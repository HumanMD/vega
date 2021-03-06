using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vega.models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        [StringLength(200)]
        public string ContactName { get; set; }
        [StringLength(200)]
        public string ContactEmail { get; set; }
        [Required]
        [StringLength(200)]
        public string ContactPhone { get; set; }
        public DateTime lastUpdate { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }

        public Vehicle()
        {
            Features = new Collection<VehicleFeature>();
        }

    }
}