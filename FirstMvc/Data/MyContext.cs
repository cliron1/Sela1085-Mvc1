using FirstMvc.Data.Entities;
using FirstMvc.Data.Views;
using Microsoft.EntityFrameworkCore;
using System;

namespace FirstMvc.Data;

public class MyContext : DbContext {
	public MyContext(DbContextOptions<MyContext> options)
		: base(options) {
	}

	// Tables
	public DbSet<User> Users { get; set; }
	public DbSet<Photo> Photos { get; set; }
	public DbSet<Category> Categories { get; set; }

    // Views
    public DbSet<VUser> VUsers { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
       modelBuilder
			.Entity<VUser>()
			.ToView("V_Users")
            .HasKey(t => t.Id);


    }
}