using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreEntityFrameworkWebAPI.Entities
{
    [Table("articles")]
    public class Article
    {
        public Article()
        {
            PublishDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("body")]
        public string Body { get; set; }

        [Required]
        [Column("publish_date")]
        public DateTime PublishDate { get; }

        [JsonIgnore]
        [Column("user_id")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
