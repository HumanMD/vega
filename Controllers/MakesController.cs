#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Persistence;
using vega.models;
using AutoMapper;
using vega.Controllers.Resources;

namespace vega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly VegaDbContext _context;
        private readonly IMapper mapper;

        public MakesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }

        // GET: api/makes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MakeResource>>> GetMakes()
        {
            var makes = await _context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }

    }
}
