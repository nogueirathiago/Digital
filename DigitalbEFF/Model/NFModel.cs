using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalbEFF.Model
{
    public class NFModel
    {
        public int Id { get; set; }

        public int NF { get; set; }

        public virtual ICollection<BalancaModel> Balancas { get; set; }

        public int Qt_Balanca { get; set; }

        public DateTime DataNF { get; set; }

        public decimal ValorNF { get; set; }

        public decimal Total { get; set; }

        public ICollection<PedidosModel> Pedidos { get; set; }
    }
}