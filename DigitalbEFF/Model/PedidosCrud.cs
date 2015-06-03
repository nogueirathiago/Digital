using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalbEFF.Model
{
    public class PedidosCrud
    {
        ContextModels db = new ContextModels();
        public string InsertOrUpdate(PedidosModel pedidos)
        {
            try
            {
                var original = db.Pedidos.Find(pedidos.Id);
                if (pedidos.Id != 0)
                {
                    db.Entry(original).CurrentValues.SetValues(pedidos);
                    db.SaveChanges();
                    return "Atualização efetuada com sucesso!";
                }
                else
                {

                    db.Pedidos.Add(pedidos);
                    db.SaveChanges();
                    return "Cadastro efetuado com sucesso!";
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error ao carregar os dados" + ex.Message);
            }

        }

        public void Delete(int id)
        {
            var cliente = db.Pedidos.Find(id);
            db.Pedidos.Remove(cliente);
            db.SaveChanges();
        }
        public List<PedidosModel> CarregarDados()
        {
            try
            {
                var dados = db.Pedidos;

                return dados.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error ao carregar os dados" + ex.Message);
            }
        }

        public PedidosModel PesquisarPorId(int id)
        {
            try
            {
                return db.Pedidos.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public PedidosModel PesquisarPorNome(int cdPedido)
        {
            try
            {
                return db.Pedidos.FirstOrDefault(x => x.Cd_Pedido == cdPedido);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}