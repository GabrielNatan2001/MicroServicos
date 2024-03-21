using MicroServicos.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicos.CartAPI.Model
{
    [Table("Product")]
    public class Product
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name{ get; set; }

        [Required]
        [Range(1, 10000)]
        public decimal Price{ get; set; }

        [StringLength(500)]
        public string Description{ get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
