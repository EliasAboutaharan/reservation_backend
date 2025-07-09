// VisitorsController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class VisitorsController : ControllerBase
{
    private static List<Visitor> visitors = new List<Visitor>();

    // GET: api/Visitors
    [HttpGet]
    public ActionResult<IEnumerable<Visitor>> GetVisitors()
    {
        return visitors;
    }

    // GET: api/Visitors/5
    [HttpGet("{id}")]
    public ActionResult<Visitor> GetVisitor(int id)
    {
        var visitor = visitors.FirstOrDefault(v => v.Id == id);
        if (visitor == null)
        {
            return NotFound();
        }
        return visitor;
    }

    // POST: api/Visitors
    [HttpPost]
    public ActionResult<Visitor> PostVisitor(Visitor visitor)
    {
        visitors.Add(visitor);
        return CreatedAtAction(nameof(GetVisitor), new { id = visitor.Id }, visitor);
    }

    // PUT: api/Visitors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVisitor(int id, Visitor visitor)
    {
        if (id != visitor.Id)
        {
            return BadRequest();
        }

        _context.Entry(visitor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VisitorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        // Retourner une réponse OK avec un message et les données du visiteur mis à jour
        return Ok(new { message = "Visitor updated successfully", data = visitor });
    }

    // DELETE: api/Visitors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVisitor(int id)
    {
        var visitor = await _context.Visitors.FindAsync(id);
        if (visitor == null)
        {
            return NotFound();
        }

        _context.Visitors.Remove(visitor);
        await _context.SaveChangesAsync();

        // Retourner une réponse OK avec un message
        return Ok(new { message = "Visitor deleted successfully" });
    }
}
