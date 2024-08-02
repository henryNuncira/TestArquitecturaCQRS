namespace TestArquitecturaCQRS.Models
{
    using Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperiences> CandidateExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring the primary keys
            modelBuilder.Entity<Candidate>()
                .HasKey(c => c.IdCandidate);

            modelBuilder.Entity<CandidateExperiences>()
                .HasKey(ce => ce.IdCandidateExperience);

            // Configuring the relationships
            modelBuilder.Entity<CandidateExperiences>()
                .HasOne(ce => ce.Candidate)
                .WithMany(c => c.CandidateExperiences)
                .HasForeignKey(ce => ce.IdCandidate)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring alternate key
            modelBuilder.Entity<Candidate>()
                .HasAlternateKey(c => c.Email);

            // Additional configurations can be added here
        }
    }
}
