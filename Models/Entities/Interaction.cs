using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskFlow.API.Models.Entities
{
    [Table("Interactions")]
    public class Interaction
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("author", TypeName = "varchar(100)")]
        public string Author { get; set; }

        [Required]
        [Column("message", TypeName = "varchar(max)")]
        public string Message { get; set; }

        [Required]
        [Column("created_date", TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column("ticket_id")]
        public int TicketId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public virtual Ticket Ticket { get; set; }
    }
}