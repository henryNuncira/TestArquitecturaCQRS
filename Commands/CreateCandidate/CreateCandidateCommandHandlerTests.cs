namespace TestArquitecturaCQRS.Commands.CreateCandidate
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using TestArquitecturaCQRS.Data;
    using Xunit;
    public class CreateCandidateCommandHandlerTests
    {
        private readonly CreateCandidateCommandHandler _handler;
        private readonly ApplicationDbContext _context;

        public CreateCandidateCommandHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _handler = new CreateCandidateCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldAddCandidate()
        {
            // Arrange
            var command = new CreateCandidateCommand
            {
                Name = "Henry",
                Surname = "Nuncira",
                Birthdate = new DateTime(1990, 1, 1),
                Email = "h.nuncira@example.com"
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            var candidate = await _context.Candidates.FindAsync(result);
            Assert.NotNull(candidate);
            Assert.Equal("Henry", candidate.Name);
            Assert.Equal("Nuncira", candidate.Surname);
            Assert.Equal(new DateTime(1990, 1, 1), candidate.Birthdate);
            Assert.Equal("h.nuncira@example.com", candidate.Email);
        }
    }
}
