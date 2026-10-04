using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskFlow.API.Models.Entities
{
[Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("title", TypeName = "varchar(150)")]
        public string Title { get; set; }

        [Column("description",TypeName = "varchar(max)")]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        [Column("requester_name", TypeName = "varchar(100)")]
        public string RequesterName { get; set; }
        [Required]
        [Column("opened_date", TypeName = "datetime2")]
        public DateTime OpenedDate { get; set; }
        [Column("closed_date", TypeName = "datetime2")]
        public DateTime ClosedDate { get; set; }
        [Column("solution", TypeName = "varchar(max)")]
        public string Solution { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("priority", TypeName = "varchar(20)")]
        public string Priority { get; set; }
        [Required]
        [MaxLength(20)]
        [Column("status", TypeName = "varchar(20)")]
        public string Status { get; set; }
        [Required]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
        public virtual ICollection<Interaction> Interactions { get; set; } = new List<Interaction>();
    }
}