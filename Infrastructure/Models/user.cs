using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table("portal_user")]
    public class PortalUserModel
    {
        [Key]
        [Column("portal_user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long user_id { get; set; }

        [Required]
        [Column("user_name")]
        public string username { get; set; } = null!;

        [Required]
        [Column("full_name")]
        public string full_name { get; set; } = null!;

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