using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jmepromeneavecmesvalises_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Jmepromeneavecmesvalises_API.Data
{
    public class Jmepromeneavecmesvalises_APIContext : IdentityDbContext<User>
    {
        public Jmepromeneavecmesvalises_APIContext (DbContextOptions<Jmepromeneavecmesvalises_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Voyage> Voyage { get; set; } = default!;
    }
}
