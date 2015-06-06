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
                    if (original.Total != balanca.Total && original.Total > balanca.Total)
                    {
                        var pesquisaNF = new NFCrud().CarregarDados().FindAll(x => x.ID_Balancas == original.Id);


                        if (pesquisaNF.Count() == 1)
                        {
                            var pesquisaPedido = new PedidosCrud().CarregarDados().FirstOrDefault(x => x.ID_Nf == pesquisaNF[0].NF);
                            if (pesquisaPedido.Situacao == "A")
                                return "Erro, não é possível atualizar pois existem balanças atreladas a Locações em aberto.";
                        }
                        else if (pesquisaNF.Count() > 1)
                        {
                            for (int i = 0; i < pesquisaNF.Count(); i++)
                            {
                                var pesquisaPedido = new PedidosCrud().CarregarDados().FirstOrDefault(x => x.ID_Nf == pesquisaNF[i].NF);
                                if (pesquisaPedido.Situacao == "A")
                                {
                                    return "Erro, não é possível atualizar pois existem balanças atreladas a Locações em aberto.";
                                }
                            }
                        }
                    }

                    if (original.Total != balanca.Total)
                    {
                        balanca.Disponíveis = balanca.Total - original.Alugadas;
                        balanca.Alugadas = original.Alugadas;
                    }

                    db.Entry(original).CurrentValues.SetValues(balanca);
                    db.SaveChanges();
                    return "Atualização efetuada com sucesso!";
                }
                else
                {
                    balanca.Disponíveis = balanca.Total;
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

        public string Delete(int id)
        {
            var original = db.Balancas.Find(id);
            var pesquisaNF = new NFCrud().CarregarDados().FindAll(x => x.ID_Balancas == original.Id);
            if (pesquisaNF.Count() > 0)
            {
                var pesquisaPedido = new PedidosCrud().CarregarDados().FirstOrDefault(x => x.ID_Nf == pesquisaNF[0].NF);
                if (pesquisaPedido.Situacao == "A")
                {
                    return "Erro, não é possível excluir pois existem balanças atreladas a Locações em aberto";
                }
            }
            var cliente = db.Balancas.Find(id);
            db.Balancas.Remove(cliente);
            db.SaveChanges();
            return "Registro Excluído com sucesso!";
        }
        public List<BalancaModel> CarregarDados()
        {
            try
            {
                var dados = db.Balancas;

                return dados.ToList();
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