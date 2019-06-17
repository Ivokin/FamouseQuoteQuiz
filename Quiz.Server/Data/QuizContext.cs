using Microsoft.EntityFrameworkCore;

namespace Quiz.Server.Data
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {}

        public DbSet<QuizQuestions> QuizQuestions { get; set; }
    }
}
