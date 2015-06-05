using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalbEFF.Model
{
    public class NFCrud
    {
        ContextModels db = new ContextModels();
        public string InsertOrUpdate(NFModel NFs)
        {
            try
            {
                var original = db.NF.Find(NFs.Id);
                if (NFs.Id != 0)
                {
                    db.Entry(original).CurrentValues.SetValues(NFs);
                    db.SaveChanges();
                    return "Atualização efetuada com sucesso!";
                }
                else
                {

                    db.NF.Add(NFs);
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
        public List<NFModel> CarregarDados()
        {
            try
            {
                var dados = db.NF;

                foreach(var dado in dados)
                {
                    var verifica = new BalancaCrud().PesquisarPorId(dado.Id);
                    if (verifica != null)
                    {
                        dado.NomeBalanca = verifica.Modelo;
                    }
                }

                return dados.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error ao carregar os dados" + ex.Message);
            }
        }

        public NFModel PesquisarPorNF(int NF)
        {
            try
            {
                return db.NF.FirstOrDefault(x => x.NF == NF);
            }
            catch (Exception)
            {

                throw;
            }
        }
      
    }
}