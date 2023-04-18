using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InforceTask.DAL
{
    public class AuthDbContext :IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options) { }
    }
}
