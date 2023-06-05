using FirstMvc.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstMvc.Data;

public class MyContext : DbContext {
	public MyContext(DbContextOptions<MyContext> options)
		: base(options) {
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Photo> Photos { get; set; }
	public DbSet<Category> Categories { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		
	}
}