using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insurance.Data.Models;
using Insurance.Business;

namespace InsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly InsuranceDBContext _context;

        public PoliciesController(InsuranceDBContext context)
        {
            _context = context;
        }

        // GET: api/Policies
        [HttpGet]
        public IEnumerable<Policy> GetPolicies()
        {
            return _context.Policies;
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var policy = await _context.Policies.FindAsync(id);

            if (policy == null)
            {
                return NotFound();
            }

            return Ok(policy);
        }

        // PUT: api/Policies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicy([FromRoute] int id, [FromBody] Policy policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policy.Id)
            {
                return BadRequest();
            }

            RiskValidator oValidator = new RiskValidator(policy.RiskType, policy.Coverage);
            var result = oValidator.ValidateRisk();

            _context.Entry(policy).State = EntityState.Modified;

            try
            {
                if (result=="OK")
                {
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return Conflict(result);
                }
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
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

        // POST: api/Policies
        [HttpPost]
        public async Task<IActionResult> PostPolicy([FromBody] Policy policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RiskValidator oValidator = new RiskValidator(policy.RiskType, policy.Coverage);
            var result = oValidator.ValidateRisk();

            if (result=="OK")
            {
                _context.Policies.Add(policy);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetPolicy", new { id = policy.Id }, policy);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // DELETE: api/Policies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var policy = await _context.Policies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            _context.Policies.Remove(policy);
            await _context.SaveChangesAsync();

            return Ok(policy);
        }

        private bool PolicyExists(int id)
        {
            return _context.Policies.Any(e => e.Id == id);
        }
    }
}