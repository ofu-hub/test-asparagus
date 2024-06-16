using Asparagus.Contracts;
using Microsoft.AspNetCore.Mvc;
using Asparagus.Models;
using Microsoft.EntityFrameworkCore;

namespace Asparagus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AsparagusController : ControllerBase
{
    private readonly ILogger<AsparagusController> _logger;
    private readonly DatabaseContext _context;
    
    public AsparagusController(ILogger<AsparagusController> logger, DatabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserSubmissionDto submission)
    {
        if (!ModelState.IsValid) return BadRequest();

        var user = await _context.Users
            .Include(u => u.Submissions)
            .FirstOrDefaultAsync(u => u.Email == submission.Email);
        
        if (user is not null)
        {
            user.SubmissionCount++;
            user.Submissions.Add(new Submission
            {
                Date = DateTime.UtcNow,
                User = user,
                UserId = user.Id
            });
            
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok($"Sent: {user.SubmissionCount}");
        }
        
        var newUser = new User
        {
            Name = submission.Name, 
            Email = submission.Email, 
            SubmissionCount = 0, 
            Submissions = new List<Submission>()
        };

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
        
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _context.Users
            .Include(u => u.Submissions)
            .ToListAsync();

        var feed = users.Select(u => new
        {
            Name = u.Name,
            SubmissionCount = u.SubmissionCount,
            LastSubmission = u.Submissions.OrderByDescending(s => s.Date).FirstOrDefault()?.Date
        });

        return Ok(feed);
    }
}