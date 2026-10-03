using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskFlow.API.Models.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public void Update(Category category)
        {
            Name = category.Name;
        }
    }
}
