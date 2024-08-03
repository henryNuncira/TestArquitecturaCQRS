namespace TestArquitecturaCQRS.Commands.CreateCandidate
{
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class CreateCandidateCommand : IRequest<int>
    {
        // ---> Data Annotations, Fluent Validation 
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Surname { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
