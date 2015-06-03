using System;
using System.Linq;
using System.Web.UI.WebControls;
using DigitalbEFF.Model;


namespace DigitalbEFF.Pages
{
    public partial class Empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarGrid();
            }
        }
        public void  CarregarGrid()
        {
            LimpaCampos();
            var db = new EmpresaCrud();
            gridDados.DataSource = db.CarregarDados();
            gridDados.DataBind();
       
        }
        protected void gridDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var cliente = new EmpresaCrud();
            var objeCliente = new EmpresaModel();
            var id = Convert.ToInt32(e.CommandArgument);
            hdn.Value = id.ToString();

            switch (e.CommandName)
            {
                case "Excluir":
                    ModalResposta.Hide();
                    cliente.Delete(id);
                    gridDados.DataBind();
                    break;

                case "Editar":
                    ModalResposta.Hide();
                    CarregarModal(id);
                    ModalInsert.Show();
                    break;

                default:
                    break;
            }
        }
        public void CarregarModal(int id)
        {
            ModalResposta.Hide();

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

        protected void btn_Pesquisar(object sender, EventArgs e)
        {
            var cliente = new EmpresaCrud();

            if (ddlPesquisa.SelectedValue == "1")
            {
                gridDados.DataSource = cliente.CarregarDados().Where(x => x.Nome.Contains(txtPesquisa.Text));
                gridDados.DataBind();
            }
            else
            {
                gridDados.DataSource = cliente.CarregarDados().Where(x => x.Nome.Contains(txtPesquisa.Text));
                gridDados.DataBind();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {


            var cliente = new EmpresaCrud();
            var objCliente = new EmpresaModel();

            objCliente.Id = hdn.Value == string.Empty ? 0 : Convert.ToInt32(hdn.Value);
            objCliente.Nome = txtNome.Text;
            objCliente.email = txtEmail.Text;
            objCliente.Cep = txtCep.Text.Replace(".", "").Replace("/", "").Replace("-", ""); ;
            objCliente.Cnpj = txtCnpj.Text.Replace(".", "").Replace("/", "").Replace("-", "");
            objCliente.Contato = txtContato.Text;
            objCliente.Endereço = txtEndereco.Text;
            objCliente.Uf = txtEstado.Text;
            objCliente.Municipio = txtMun.Text;
            objCliente.Telefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", ""); ;

            var cadastro = cliente.InsertOrUpdate(objCliente);

            txtResposta.Text = cadastro;
            CarregarGrid();
            gridDados.DataBind();
            ModalResposta.Show();


        }
        public void LimpaCampos()
        {
            hdn.Value = string.Empty;
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtCnpj.Text = string.Empty;
            txtContato.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtMun.Text = string.Empty;
            txtTelefone.Text = string.Empty;
        }
    }
}