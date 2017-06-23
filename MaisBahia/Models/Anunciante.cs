using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaisBahia.Models
{ 
    public class Anunciante
    {

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("Endereco")]
        [Required]
        [MaxLength(100)]
        public string Endereco { get; set; }

        [Column("Telefone")]
        [Required]
        [MaxLength(50)]
        public string  Telefone { get; set; }

        [Column("Email")]
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Column("Descricao")]
        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }
        
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria categoria { get; set; }

        public int PlanoId { get; set; }
        [ForeignKey("PlanoId")]
        public Plano plano { get; set; }
        public Plano Valor { get; set; }

    }
}