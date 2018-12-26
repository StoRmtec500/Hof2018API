using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schaf.Models
{
    public class AblammContext : DbContext
    {
        public AblammContext(DbContextOptions<AblammContext> options) : base(options) { }

        public DbSet<Ablamm2018> Ablamm2018 { get; set; }
    
    }
}
