using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace practica01.Models
{    
    [Table("t_producto")]
    public class Producto
    {    
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] 
        public int Id {get; set;}

        [Column("name")]
        [Required]
        public string nombre {get; set;}
         
        [Required]
        public string categoria {get; set;}
         
         [Required]
        public float precio {get; set;}
         
         [Required]
        public float descuento {get; set;}
    }
}