namespace TestArquitecturaCQRS.Commands.CreateCandidate
{
    using MediatR;

    public class CreateCandidateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
    }
}
