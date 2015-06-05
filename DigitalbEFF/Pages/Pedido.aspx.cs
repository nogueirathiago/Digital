using System;
using System.Linq;
using System.Web.UI.WebControls;
using DigitalbEFF.Model;


namespace DigitalbEFF.Pages
{
    public partial class Pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarGrid();
            }
        }
        public void CarregarGrid()
        {

            LimpaCampos();
            ddlEmpresa_Bind();
            var db = new PedidosCrud();
            gridDados.DataSource = db.CarregarDados();
            gridDados.DataBind();

        }
        protected void gridDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var cliente = new EmpresaCrud();
            var objeCliente = new EmpresaModel();
            var id = Convert.ToInt32(e.CommandArgument);
            int idNF = Convert.ToInt32(gridDados.Rows[id].Cells[1].Text);
            hdn.Value = id.ToString();
            hdnFim.Value = string.Empty;
            

            switch (e.CommandName)
            {
                case "Excluir":
                    ModalResposta.Hide();
                    cliente.Delete(id);
                    gridDados.DataBind();
                    break;

                case "Editar":
                    rfvDtRetorno.Enabled = false;
                    DateValidator1.Enabled = false;
                    ModalResposta.Hide();
                    CarregarModal(id);
                    ModalInsert.Show();
                    break;
                case "Finalizar":
                    rfvDtRetorno.Enabled = true;
                    DateValidator1.Enabled = true;
                    hdnFim.Value = "Sim";
                    ModalResposta.Hide();
                    CarregarModal(id);
                    ModalInsert.Show();
                    break;
                case "NF":
                    CarregarModalNF(idNF);
                    ModalNF.Show();
                    break;
                default:
                    break;
            }
        }
        public void CarregarModal(int id)
        {
            ModalResposta.Hide();
            var user = new PedidosCrud();
            ddlEmpresa_Bind();
            txtCd_Pedido.Text = id.ToString();
            if (id != 0)
            {
                var objUser = user.PesquisarPorId(id);
                txtNF.Text = objUser.ID_Nf.ToString();
                ddlEmpresa.SelectedValue = objUser.ID_Empresa.ToString();
                txtDtLocacao.Text = objUser.DataLocacao.ToString();
                txtDtRetorno.Text = objUser.DataRetorno.ToString();
            }
            else
            {
                rfvDtRetorno.Enabled = false;
                DateValidator1.Enabled = false;
            }
            txtCd_Pedido.Enabled = false;

            if (hdnFim.Value != string.Empty)
            {
                txtNF.Enabled = false;
                ddlEmpresa.Enabled = false;
                txtDtLocacao.Enabled = false;
            }
            else
            {
                txtNF.Enabled = true;
                ddlEmpresa.Enabled = true;
                txtDtLocacao.Enabled = true;
            }

        }

        public void CarregarModalNF(int id)
        {
            var user = new PedidosCrud();
            ddlEmpresa_Bind();
            txtCd_Pedido.Text = id.ToString();
            if (id != 0)
            {
                var objUser = user.PesquisarPorId(id);
                txtNF.Text = objUser.ID_Nf.ToString();
                ddlEmpresa.SelectedValue = objUser.ID_Empresa.ToString();
                txtDtLocacao.Text = objUser.DataLocacao.ToString();
                txtDtRetorno.Text = objUser.DataRetorno.ToString();
            }
            else
            {
                rfvDtRetorno.Enabled = false;
                DateValidator1.Enabled = false;
            }
            txtCd_Pedido.Enabled = false;

            if (hdnFim.Value != string.Empty)
            {
                txtNF.Enabled = false;
                ddlEmpresa.Enabled = false;
                txtDtLocacao.Enabled = false;
            }
            else
            {
                txtNF.Enabled = true;
                ddlEmpresa.Enabled = true;
                txtDtLocacao.Enabled = true;
            }

        }


        protected void ddlEmpresa_Bind()
        {
            var empresa = new EmpresaCrud().CarregarDados();
            ddlEmpresa.DataSource = empresa;
            ddlEmpresa.DataValueField = "Id";
            ddlEmpresa.DataTextField = "Nome";
            ddlEmpresa.DataBind();
            ddlEmpresa.Items.Insert(0, new ListItem("Selecione..."));
        }
        protected void ddlBalanca_Bind()
        {
            var balanca = new BalancaCrud().CarregarDados();
            ddlEmpresa.DataSource = balanca;
            ddlEmpresa.DataValueField = "Id";
            ddlEmpresa.DataTextField = "Modelo";
            ddlEmpresa.DataBind();
            ddlEmpresa.Items.Insert(0, new ListItem("Selecione..."));
        }
        protected void btn_Pesquisar(object sender, EventArgs e)
        {
            var cliente = new PedidosCrud();

            if (ddlPesquisa.SelectedValue == "1")
            {
                gridDados.DataSource = cliente.CarregarDados().Where(x => x.Id.ToString() == txtPesquisa.Text);
                gridDados.DataBind();
            }
            else
            {
                gridDados.DataSource = cliente.CarregarDados().Where(x => x.Id.ToString() == txtPesquisa.Text);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {


            var cliente = new PedidosCrud();
            var objCliente = new PedidosModel();

            objCliente.Id = hdn.Value == string.Empty ? 0 : Convert.ToInt32(hdn.Value);
            //objCliente.Cd_Pedido = Convert.ToInt32(txtCd_Pedido.Text);
            objCliente.ID_Nf = Convert.ToInt32(txtNF.Text);
            objCliente.ID_Empresa = Convert.ToInt32(ddlEmpresa.SelectedValue);
            objCliente.DataLocacao = Convert.ToDateTime(txtDtLocacao.Text.Substring(0, 10));

            if (txtDtRetorno.Text != string.Empty)
            {
                objCliente.DataRetorno = Convert.ToDateTime(txtDtRetorno.Text.Substring(0, 10));
                objCliente.Situacao = "I";

            }
            else
            {
                objCliente.DataRetorno = null;
                objCliente.Situacao = "A";
            }





            var cadastro = cliente.InsertOrUpdate(objCliente);

            txtResposta.Text = cadastro;
            CarregarGrid();
            gridDados.DataBind();
            ModalResposta.Show();


        }
        public void LimpaCampos()
        {
            hdn.Value = string.Empty;
            hdnFim.Value = string.Empty;
            txtCd_Pedido.Text = string.Empty;
            txtNF.Text = string.Empty;
            txtDtRetorno.Text = string.Empty;
            txtDtLocacao.Text = string.Empty;
            ddlEmpresa.Items.Clear();

        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            ModalResposta.Hide();
            CarregarModal(0);
            ModalInsert.Show();
        }

        protected void BtnNF_Click(object sender, EventArgs e)
        {

        }





    }
}