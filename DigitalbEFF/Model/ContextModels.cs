using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DigitalbEFF.Model
{
    public class ContextModels : DbContext
    {
        public DbSet<EmpresaModel> Empresas { get; set; }
        public DbSet<BalancaModel> Balancas { get; set; }
        public DbSet<NFModel> NF { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }
    }
}