using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebapi.Models
{
   [Table("sds")]
   public class s
   {
       [Key]
       [Column("s1")]
       public string s1 { get; set; }
       [Required]
       [Column("s2")]
       public string s2 { get; set; }
       [Required]
       [Column("s3")]
        public string s3 { get; set; }
   }

    [Table("student")]
   public class Students
   {
       [Key]
       [Column("ID")]
       public string ID { get; set; }
       [Required]
       [Column("UserNo")]
       public string UserNo { get; set; }
       [Required]
       [Column("UserName")]
        public string UserName { get; set; }
        [Required]
       [Column("Userlevel")]
        public string Userlevel { get; set; }
        [Required]
       [Column("Password")]
        public string password { get; set; }
   }
   
   
}


