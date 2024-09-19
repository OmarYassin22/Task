using AutoMapper;
using BL.Interfaces;
using BL.ViewModels;
using DAL.Data;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository _repository;
        private readonly IMapper _mapper;

        public ApplicantController(IApplicantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/<Applicant>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicantDTO>>> Get()
        {
            var applicants = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<ApplicantDTO>>(applicants);
            return Ok(result);
        }

        // GET api/<Applicant>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicantDTO>> Get(int id)
        {
            var applicant = await _repository.GetAsync(id);
            var result = _mapper.Map<ApplicantDTO>(applicant);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // POST api/<Applicant>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplicantDTO applicantDTO)
        {
            var applicant = _mapper.Map<Applicant>(applicantDTO);
            var result = await _repository.AddAPIAsync(applicant);
            if (result != null)
                return Ok(_mapper.Map<ApplicantDTO>(result));
            return BadRequest("InValid Applicant");



        }

        // PUT api/<Applicant>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ApplicantDTO applicantDTO)
        {
            var applicant = _mapper.Map<Applicant>(applicantDTO);
            applicant.Id = id;
            var count = await _repository.UpdateAsync(applicant);
            if (count > 0)
                return Ok("Applicant Updated Successfully");
            return BadRequest("InValid Applicant");

        }

        // DELETE api/<Applicant>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var count = await _repository.DeleteAsync(id);
            if (count > 0)
                return Ok("Applicant Deleted Successfully");
            return BadRequest("InValid Applicant");
        }
    }
}
