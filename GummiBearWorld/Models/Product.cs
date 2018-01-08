using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
	[Table("Product")]
	public class Item
	{
		[Key]
		public int id { get; set; }
		public string Description { get; set; }
		public string CategoryId { get; set; }
        public int Cost { get; set; }
		public virtual Category Category { get; set; }
	}
}