using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisBahia.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public byte[] Arquivo { get; set; }
        public string MimeType { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
