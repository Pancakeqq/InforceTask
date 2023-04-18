
using InforceTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace InforceTask.DAL
{
    public class LinksDbContext : DbContext
    {
        public LinksDbContext(DbContextOptions<LinksDbContext> options) : base(options)
        { }

        public DbSet<Link> Links { get; set; }

    }
}
