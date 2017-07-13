using MaisBahia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisBahia.DataAccess
{
    public class AnuncianteInit : CreateDatabaseIfNotExists<MaisBahiaContext>
    {
        protected override void Seed(MaisBahiaContext contexto)
        {
            List<Categoria> categorias = new List<Categoria>()
            {
                new Categoria() { Nome = "Academia" },
                new Categoria() { Nome = "Açai" },
                new Categoria() { Nome = "Bolos e Tortas" },
                new Categoria() { Nome = "Buffet" },
                new Categoria() { Nome = "Climatização" },
                new Categoria() { Nome = "Dentistas" },
                new Categoria() { Nome = "Engenharia e Serviços" },
                new Categoria() { Nome = "Escolar" },
                new Categoria() { Nome = "Farmacias" },
                new Categoria() { Nome = "Farmacias de Manipulação" },
                new Categoria() { Nome = "Hotelaria" },
                new Categoria() { Nome = "Imóveis" },
                new Categoria() { Nome = "Informática" },
                new Categoria() { Nome = "Manutenção e Acessorios" },
                new Categoria() { Nome = "Materiais de Construção" },
                new Categoria() { Nome = "Oficinas" },
                new Categoria() { Nome = "Onde tem Festas" },
                new Categoria() { Nome = "Prestadores de Serviços" },
                new Categoria() { Nome = "Pizzaria" },
                new Categoria() { Nome = "Restaurantes" },
                new Categoria() { Nome = "Sorveteria" },
            };

            categorias.ForEach(c => contexto.Categorias.Add(c));

            List<Plano> planos = new List<Plano>()
            {
                new Plano() { Nome = "Mensal", Valor=40.50F},
                new Plano() { Nome = "Trimestral",Valor=30.75F },
                new Plano() { Nome = "Anual",Valor=10.75F },
            };

            List<Anunciante> anunciantes = new List<Anunciante>()
            {
                new Anunciante() {
                            Nome = "Life Body",
                            Categoria = categorias.FirstOrDefault(c => c.Nome == "Academia"),
                            Endereco = "Rua Landulfo Alves n 18 Engomadeira",
                            Telefone = "7133571057",
                            Email = "email@aicom.com.br",
                            Descricao ="Ambiente Climatizado",
                            Plano=planos.FirstOrDefault(p=>p.Nome=="Mensal")
                },
                new Anunciante() {
                            Nome = "Imobiliária Santa Luz",
                            Categoria = categorias.FirstOrDefault(c => c.Nome == "Imóveis"),
                            Endereco = "Rua Landulfo Alves n 18 Engomadeira",
                            Telefone = "7133571057",
                            Email = "email@santaluz.com.br",
                            Descricao ="Ambiente Climatizado",
                            Plano=planos.FirstOrDefault(p=>p.Nome=="Anual")
                }
            };

            planos.ForEach(p => contexto.Planos.Add(p));
            contexto.SaveChanges();
        }
    }
}
