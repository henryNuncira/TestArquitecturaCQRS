using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestArquitecturaCQRS.Models;
using TestArquitecturaCQRS.Commands.CreateCandidate;
using TestArquitecturaCQRS.Queries.GetCandidates;
using Microsoft.AspNetCore.Authorization;

namespace TestArquitecturaCQRS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        //[Authorize(Roles = "Admin")]   ---->Authorizations by rols
        public async Task<IActionResult> Create(CreateCandidateCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<Candidate>> Get()
        {
            return await _mediator.Send(new GetCandidatesQuery());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await _mediator.Send(new GetCandidatesQuery());
            var candidate = candidates.FirstOrDefault(c => c.IdCandidate == id);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }
    }
}
