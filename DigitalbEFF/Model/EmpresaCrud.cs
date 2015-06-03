using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using System.Web.UI.WebControls;

namespace DigitalbEFF.Model
{

    public class EmpresaCrud
    {
        ContextModels db = new ContextModels();
        public string InsertOrUpdate(EmpresaModel empresa)
        {
            try
            {
                var original = db.Empresas.Find(empresa.Id);
                if (empresa.Id != 0)
                {
                    db.Entry(original).CurrentValues.SetValues(empresa);
                    db.SaveChanges();
                    return "Atualização efetuada com sucesso!";
                }
                else
                {
                    var existente = db.Empresas.Where(i => i.Cnpj == empresa.Cnpj);

                    if (existente != null)
                    {
                        return "Já existe uma empresa com o mesmo CNPJ cadastrado!";
                    }

                    db.Empresas.Add(empresa);
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
            var cliente = db.Empresas.Find(id);
            db.Empresas.Remove(cliente);
            db.SaveChanges();
        }
        public List<EmpresaModel> CarregarDados()
        {
            try
            {
                var dados = db.Empresas;

                return dados.ToList();
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public EmpresaModel PesquisarPorNome(string nome)
        {
            try
            {
                return db.Empresas.FirstOrDefault(x => x.Nome.Contains(nome));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}