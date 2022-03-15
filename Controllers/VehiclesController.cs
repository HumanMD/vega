using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resources;
using vega.models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            // INUTILE, i controlli sulle annotazioni vengono fatte prima della call!
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var model = await context.Models.FindAsync(vehicleResource.ModelId);

            if(model == null){
                ModelState.AddModelError("ModelId", "Invalid modelId");
                return BadRequest(ModelState);
            }

            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.lastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

    }

}