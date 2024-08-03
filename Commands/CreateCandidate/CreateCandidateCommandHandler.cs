namespace TestArquitecturaCQRS.Commands.CreateCandidate
{
    using MediatR;
    using TestArquitecturaCQRS.Data;
    using TestArquitecturaCQRS.Models;

    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateCandidateCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = new Candidate
            {
                Name = request.Name,
                Surname = request.Surname,
                Birthdate = request.Birthdate,
                Email = request.Email,
                InsertDate = DateTime.UtcNow
            };

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            return candidate.IdCandidate;
        }
    }
}
