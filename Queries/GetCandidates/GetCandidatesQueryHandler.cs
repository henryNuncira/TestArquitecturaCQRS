namespace TestArquitecturaCQRS.Queries.GetCandidates
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using TestArquitecturaCQRS.Data;
    using TestArquitecturaCQRS.Models;

    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, List<Candidate>>
    {
        private readonly ApplicationDbContext _context;

        public GetCandidatesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Candidate>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Candidates.ToListAsync(cancellationToken);
        }
    }
}
