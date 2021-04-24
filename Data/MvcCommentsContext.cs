using Microsoft.EntityFrameworkCore;
using MvcComments.Models;

namespace MvcComments.Data
{
    public class MvcCommentsContext : DbContext
    {
        public MvcCommentsContext (DbContextOptions<MvcCommentsContext> options)
            : base(options)
        {
        }

        public DbSet<Comments> Comments { get; set; }
    }
}