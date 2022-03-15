using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Controllers.Resources;
using vega.models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly VegaDbContext _context;
        private readonly IMapper mapper;

        public FeaturesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }

        // GET: api/features
        public async Task<ActionResult<IEnumerable<FeatureResource>>> GetFeatures()
        {
            var features = await _context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}