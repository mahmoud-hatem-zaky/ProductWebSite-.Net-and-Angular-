using Microsoft.AspNetCore.Mvc;
using ProductRequestsAPI.Data;
using ProductRequestsAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ProductRequestsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.Include(r => r.Products).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Request>> SubmitRequest([FromBody] Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRequests), new { id = request.Id }, request);
        }
    }

}
