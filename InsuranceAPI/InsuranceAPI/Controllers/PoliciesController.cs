using Insurance.Business;
using Insurance.Data.Models;
using Insurance.Repos;
using Insurance.Repos.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyRepository _policyRepository;

        public PoliciesController(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        // GET: api/Policies
        [HttpGet]
        public IEnumerable<Policy> GetPolicies()
        {
            return _policyRepository.GetPolicies();
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicy([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var policy = _policyRepository.GetPolicy(id);

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

            try
            {
                if (result=="OK")
                {
                    _policyRepository.Update(policy);
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
                _policyRepository.Add(policy);
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

            var policy = _policyRepository.GetPolicy(id);
            if (policy == null)
            {
                return NotFound();
            }

            _policyRepository.Delete(id);

            return Ok(policy);
        }

        private bool PolicyExists(int id)
        {
            return _policyRepository.PolicyExists(id);
        }
    }
}