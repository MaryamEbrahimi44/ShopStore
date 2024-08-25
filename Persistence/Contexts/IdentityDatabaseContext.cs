using Application.Interfaces;
using Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class IdentityDatabaseContext:IdentityDbContext<User>, IIdentityDatabaseContext
    {
        public IdentityDatabaseContext(DbContextOptions<IdentityDatabaseContext> options):base(options)
        {
            
        }
    }
}
