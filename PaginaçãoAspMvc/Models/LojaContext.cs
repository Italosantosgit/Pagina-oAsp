using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaginaçãoAspMvc.Models
{
    public class LojaContext : DbContext
    {
        public LojaContext() : base("LojaDb")
        {
            Database.SetInitializer<LojaContext>(new CreateDatabaseIfNotExists<LojaContext>());
            Database.Initialize(false);
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}