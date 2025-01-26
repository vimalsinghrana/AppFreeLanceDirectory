using AppFreeLanceDirectory;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FreelancersController : ControllerBase
{
	private readonly FreelancerContext _context;

	public FreelancersController(FreelancerContext context)
	{
		_context = context;
	}

	// GET: api/freelancers
	[HttpGet]
	public async Task<ActionResult<IEnumerable<User>>> GetFreelancers()
	{
		return await _context.Users.ToListAsync();
	}

	// GET: api/freelancers/5
	[HttpGet("{id}")]
	public async Task<ActionResult<User>> GetFreelancer(int id)
	{
		var user = await _context.Users.FindAsync(id);

		if (user == null)
		{
			return NotFound();
		}

		return user;
	}

	// POST: api/freelancers
	[HttpPost]
	public async Task<ActionResult<User>> PostFreelancer(User user)
	{
		_context.Users.Add(user);
		await _context.SaveChangesAsync();

		return CreatedAtAction("GetFreelancer", new { id = user.Id }, user);
	}

	// PUT: api/freelancers/5
	[HttpPut("{id}")]
	public async Task<IActionResult> PutFreelancer(int id, User user)
	{
		if (id != user.Id)
		{
			return BadRequest();
		}

		_context.Entry(user).State = EntityState.Modified;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!UserExists(id))
			{
				return NotFound();
			}
			else
			{
				throw;
			}
		}

		return NoContent();
	}

	// DELETE: api/freelancers/5
	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteFreelancer(int id)
	{
		var user = await _context.Users.FindAsync(id);
		if (user == null)
		{
			return NotFound();
		}

		_context.Users.Remove(user);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool UserExists(int id)
	{
		return _context.Users.Any(e => e.Id == id);
	}
}