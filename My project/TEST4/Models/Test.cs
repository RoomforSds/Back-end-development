using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebapi.Models
{
    [Table("Test")]
   public class Test
   {
       [Key]
       [Column("ID")]
       public string ID { get; set; }
       [Required]
       [Column("Temp")]
       public string Temp { get; set; }
       [Required]
       [Column("CurrentSpeed")]
        public string CurrentSpeed { get; set; }
        [Required]
       [Column("Sicon")]
        public string Sicon { get; set; }
        [Required]
       [Column("Ratio")]
        public string Ratio { get; set; }
   }
}