using GlimseCrafts.Website.Models;
using Microsoft.EntityFrameworkCore;

namespace GlimseCrafts.Website.Data
{
    public class ApplicationDBContest : DbContext
    {
        public ApplicationDBContest(DbContextOptions<ApplicationDBContest> options) : base(options)
        {          
        }

        public DbSet<Category> Categories { get; set; }
    }
}
