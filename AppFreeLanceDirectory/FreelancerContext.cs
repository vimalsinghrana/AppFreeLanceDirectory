using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace AppFreeLanceDirectory
{
	public class FreelancerContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Skillset> Skillsets { get; set; }
		public DbSet<Hobby> Hobbies { get; set; }

		public FreelancerContext(DbContextOptions<FreelancerContext> options)
		: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Skillset>()
				.HasOne(s => s.Freelancer)
				.WithMany(u => u.Skillsets)
				.HasForeignKey(s => s.FreelancerId);

			modelBuilder.Entity<Hobby>()
				.HasOne(h => h.Freelancer)
				.WithMany(u => u.Hobbies)
				.HasForeignKey(h => h.FreelancerId);
		}
	}
}
