using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("checkin")]
    public class CheckinModel
    {
        [Key]
        [Column("checkin_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long checkin_id { get; set; }

        [Required]
        [Column("status")]
        public string status { get; set; } = null!;

        [Column("message")]
        public string? message { get; set; }

        [Column("user_id")]
        public long user_id { get; set; }

        [Column("created_timestamp")]
        public DateTime created_timestamp { get; set; }

        [Column("created_by_id")]
        public long created_by_id { get; set; }

        [Column("updated_timestamp")]
        public DateTime updated_timestamp { get; set; }

        [Column("updated_by_id")]
        public long updated_by_id { get; set; }
    }
}