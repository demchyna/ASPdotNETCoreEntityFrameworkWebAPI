using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreEntityFrameworkWebAPI.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [JsonIgnore]
        [Column("role_id")]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        [JsonIgnore]
        public ICollection<Article> Articles { get; set; }
    }
}
