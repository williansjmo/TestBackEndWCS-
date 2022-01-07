using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Domain.Entities;
using Test.Domain.Interfaces;
using Test.Domain.Services;
using Test.Domain.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    [Route("api/[controller]")]
    public class CandidateController : Controller
    {
        private readonly IGenericService<Candidate> generic;

        public CandidateController(CandidateService candidateService)
        {
            generic = candidateService;
        }

        //POST: api/values
        [HttpPost("{search}")]
        public async Task<IActionResult> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
                return BadRequest();
            return Ok(await generic.Search(search));
        }

        // GET: api/values
        [HttpGet]
        public async Task<Result> Get()
        {
            return await generic.GetAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(object id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return BadRequest();

            return Ok(await generic.GetAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Candidate candidate)
        {
            if(ModelState.IsValid)
                return Ok(await generic.AddAsync(candidate));

            return  BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(object id, [FromBody] Candidate candidate)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return BadRequest();

            if (ModelState.IsValid)
            {
                candidate.Id = Guid.Parse(id.ToString());
                return Ok(await generic.UpdateAsync(candidate));
            }

            return BadRequest(ModelState);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(object id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return BadRequest();

            return Ok(await generic.DeleteAsync(id));
        }
    }
}
