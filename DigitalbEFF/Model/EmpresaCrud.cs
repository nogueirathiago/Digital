using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Web.UI.WebControls;

namespace DigitalbEFF.Model
{

    public class EmpresaCrud
    {
        ContextModels db = new ContextModels();
        public void InsertOrUpdate(EmpresaModel empresa)
        {
            db.Entry(empresa).State = empresa.Id == 0 ? EntityState.Added : EntityState.Modified;   
        }

        public void Delete(int id)
        {
            var cliente = db.Empresas.Find(id);
            db.Empresas.Remove(cliente);
            db.SaveChanges();
        }
        public IQueryable<EmpresaModel> CarregarDados()
        {
            try
            {
                var dados = db.Empresas;

                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception("Error ao carregar os dados" + ex.Message);
            }
        }

        public EmpresaModel PesquisarPorId(int id)
        {
            try
            {
                return db.Empresas.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        

    }
}