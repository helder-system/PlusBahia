using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaisBahia.Models
{
    public class Anunciante
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Endereco { get; set; }

        [Required]
        [MaxLength(50)]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }

        public byte[] ArquivoFoto { get; set; }
        public string MimeType { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int PlanoId { get; set; }
        public Plano Plano { get; set; }

    }
}
