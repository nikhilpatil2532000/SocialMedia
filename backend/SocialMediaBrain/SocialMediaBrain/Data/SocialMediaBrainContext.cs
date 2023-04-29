using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialMediaBrain.Models;

namespace SocialMediaBrain.Data
{
    public class SocialMediaBrainContext : DbContext
    {
        public SocialMediaBrainContext (DbContextOptions<SocialMediaBrainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Name=SocialMediaBrainContext");
        }
    }
}
