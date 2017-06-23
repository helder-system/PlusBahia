using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaisBahia.Models
{
    public class Plano
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("Valor")]
        [Required]
        public float Valor { get; set; }
    }
}