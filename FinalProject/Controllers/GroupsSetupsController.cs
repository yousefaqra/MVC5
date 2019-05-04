using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsSetupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroupsSetupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/GroupsSetups
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await _context.Groups.ToListAsync();
            return Ok(groups);
        }

        // GET: api/GroupsSetups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupsSetup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupsSetup = await _context.Groups.FindAsync(id);

            if (groupsSetup == null)
            {
                return NotFound();
            }

            return Ok(groupsSetup);
        }

        // PUT: api/GroupsSetups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupsSetup([FromRoute] int id, [FromBody] GroupsSetup groupsSetup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupsSetup.ID)
            {
                return BadRequest();
            }

            _context.Entry(groupsSetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupsSetupExists(id))
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

        // POST: api/GroupsSetups
        [HttpPost]
        public async Task<IActionResult> PostGroupsSetup([FromBody] GroupsSetup groupsSetup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Groups.Add(groupsSetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupsSetup", new { id = groupsSetup.ID }, groupsSetup);
        }

        // DELETE: api/GroupsSetups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupsSetup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupsSetup = await _context.Groups.FindAsync(id);
            if (groupsSetup == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(groupsSetup);
            await _context.SaveChangesAsync();

            return Ok(groupsSetup);
        }

        private bool GroupsSetupExists(int id)
        {
            return _context.Groups.Any(e => e.ID == id);
        }
    }
}