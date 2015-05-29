using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigitalbEFF.Model;


namespace DigitalbEFF
{
    public partial class Empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<EmpresaModel> CarregarGrid()
        {
            var db = new EmpresaCrud();
            return db.CarregarDados();
        }

        public void FormCadastro_InsertItem()
        {
            var db = new EmpresaCrud();
            var item = new EmpresaModel();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                db.InsertOrUpdate(item);
                gridDados.DataBind();
            }
        }
        protected void gridDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var cliente = new EmpresaCrud();
            var objeCliente = new EmpresaModel();
            var id = Convert.ToInt32(e.CommandArgument);
            hdn.Value = id.ToString();

            switch (e.CommandName)
            {
                case "Adicionar":
                    ModalInsert.Show();
                    break;
                case "Excluir":
                    cliente.Delete(id);
                    gridDados.DataBind();
                    break;

                case "Editar":

                    CarregarModal(id);
                    ModalUpdate.Show();
                    break;

                default:
                    break;
            }
        }
        public void CarregarModal(int id)
        {
            var user = new EmpresaCrud();

            var objUser = user.PesquisarPorId(id);

            objUser.Id = Convert.ToInt32(hdn.Value);
            txtNome.Text = objUser.Nome;
            txtEmail.Text = objUser.email;
            txtCep.Text = objUser.Cep;
            txtCnpj.Text = objUser.Cnpj;
            txtContato.Text = objUser.Contato;
            txtEndereco.Text = objUser.Endereço;
            txtEstado.Text = objUser.Uf;
            txtMun.Text = objUser.Municipio;
            txtTelefone.Text = objUser.Telefone;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            var cliente = new EmpresaCrud();
            var objCliente = new EmpresaModel();

            objCliente.Nome = txtNome.Text;
            objCliente.email = txtEmail.Text;
            objCliente.Cep = txtCep.Text;
            objCliente.Cnpj = txtCnpj.Text;
            objCliente.Contato = txtContato.Text;
            objCliente.Endereço = txtEndereco.Text;
            objCliente.Uf = txtEstado.Text;
            objCliente.Municipio = txtMun.Text;
            objCliente.Telefone = txtTelefone.Text;

            cliente.InsertOrUpdate(objCliente);

            gridDados.DataBind();

        }
    }
}