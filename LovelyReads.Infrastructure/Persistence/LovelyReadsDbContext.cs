using LovelyReads.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LovelyReads.Infrastructure.Persistence;

public class LovelyReadsDbContext : DbContext
{
	public LovelyReadsDbContext(DbContextOptions<LovelyReadsDbContext> options) : base(options)
	{

	}

	public DbSet<Author> Authors { get; set; }
	public DbSet<Book> Books { get; set; }
	public DbSet<Genre> Genres { get; set; }
	public DbSet<BookReview> BookReviews { get; set; }
	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
