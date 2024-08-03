namespace TestArquitecturaCQRS.Queries.GetCandidates
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using TestArquitecturaCQRS.Data;
    using TestArquitecturaCQRS.Models;
    using Xunit;
    public class GetCandidatesQueryHandlerTests
    {
        private readonly GetCandidatesQueryHandler _handler;
        private readonly ApplicationDbContext _context;

        public GetCandidatesQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _handler = new GetCandidatesQueryHandler(_context);

            // Seed the database
            _context.Candidates.AddRange(new List<Candidate>
        {
            new Candidate { Name = "Henry", Surname = "Nuncira", Birthdate = new DateTime(1990, 1, 1), Email = "h.nuncira@example.com" },
            new Candidate { Name = "Victor", Surname = "Estrada", Birthdate = new DateTime(1992, 2, 2), Email = "v.estrada@example.com" }
        });
            _context.SaveChanges();
        }

        [Fact]
        public async Task Handle_ShouldReturnAllCandidates()
        {
            // Arrange
            var query = new GetCandidatesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
