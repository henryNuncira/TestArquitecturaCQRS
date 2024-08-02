namespace TestArquitecturaCQRS.Queries.GetCandidates
{
    using MediatR;
    using TestArquitecturaCQRS.Models;
    using System.Collections.Generic;

    public class GetCandidatesQuery : IRequest<List<Candidate>>
    {
    }
}
