using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalbEFF.Model
{
    public class BalancaCrud
    {
        ContextModels db = new ContextModels();
        public string InsertOrUpdate(BalancaModel balanca)
        {
            try
            {
                var original = db.Balancas.Find(balanca.Id);
                if (balanca.Id != 0)
                {
                    db.Entry(original).CurrentValues.SetValues(balanca);
                    db.SaveChanges();
                    return "Atualização efetuada com sucesso!";
                }
                else
                {

                    db.Balancas.Add(balanca);
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
            var cliente = db.Balancas.Find(id);
            db.Balancas.Remove(cliente);
            db.SaveChanges();
        }
        public IQueryable<BalancaModel> CarregarDados()
        {
            try
            {
                var dados = db.Balancas;

                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ao carregar os dados" + ex.Message);
            }
        }

        public BalancaModel PesquisarPorId(int id)
        {
            try
            {
                return db.Balancas.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public BalancaModel PesquisarPorNome(string nome)
        {
            try
            {
                return db.Balancas.FirstOrDefault(x => x.Modelo.Contains(nome));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}