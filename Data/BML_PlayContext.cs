using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BML_Play.Models;

namespace BML_Play.Data
{
    public class BML_PlayContext : DbContext
    {
        public BML_PlayContext (DbContextOptions<BML_PlayContext> options)
            : base(options)
        {
        }

        public DbSet<BML_Play.Models.Filme> Filme { get; set; } = default!;
    }
}
