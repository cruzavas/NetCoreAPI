using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie1.Models
{
    public class MvcMovie1Context : DbContext
    {
        public MvcMovie1Context (DbContextOptions<MvcMovie1Context> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie1.Models.Movie> Movie { get; set; }
    }
}
