using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schaf.Models
{
    public class EinstellungenContext : DbContext
    {
        public EinstellungenContext(DbContextOptions<EinstellungenContext> options) : base(options) { }

        public DbSet<Einstellungen> Einstellungen { get; set; }
    }
}
