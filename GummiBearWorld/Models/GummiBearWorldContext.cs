using Microsoft.EntityFrameworkCore;

namespace GummiBearKingdom.Models
{
	public class GummiBearWoldContext : DbContext
	{
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Item> Items { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder
			.UseMySql(@"Server=localhost;Port=8889;database=todolist;uid=root;pwd=root;");
	}
}