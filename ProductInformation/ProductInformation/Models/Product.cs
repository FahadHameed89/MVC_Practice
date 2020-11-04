using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInformation.Models
{
    [Table("product"]
    public class Product
    {

        public Product()
        {
            // FK Category 
        }
        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "varchar(40)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "int(10)")]
        public int CategoryID { get; set; }



    }
}
