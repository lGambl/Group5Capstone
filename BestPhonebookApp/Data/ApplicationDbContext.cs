using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BestPhonebookApp.Models;

namespace BestPhonebookApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BestPhonebookApp.Models.PhonebookEntry> PhonebookEntry { get; set; } = default!;
    }
}
