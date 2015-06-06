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
            var objCliente = new EmpresaModel();
            var id = Convert.ToInt32(e.CommandArgument);
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
                    CarregarModalNF(id);
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
            var pedido = new PedidosCrud().PesquisarPorNF(id);
            var user = new NFCrud().PesquisarPorNF(id);

            lblTitPedido.Text = pedido.Id.ToString();
            lblTitEmpresa.Text = pedido.NomeEmpresa;
            lblTitNf.Text = pedido.ID_Nf.ToString();
            gdvNF.DataSource = user;
            gdvNF.DataBind();

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
        protected void ddlBalanca_Bind(DropDownList ddlBalanca)
        {
            var balanca = new BalancaCrud().CarregarDados();
            ddlBalanca.DataSource = balanca;
            ddlBalanca.DataValueField = "Id";
            ddlBalanca.DataTextField = "Modelo";
            ddlBalanca.DataBind();
            ddlBalanca.Items.Insert(0, new ListItem("Selecione..."));
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


            if (objCliente.Situacao == "I")
            {
                var pesquisaNF = new NFCrud().PesquisarPorNF(objCliente.ID_Nf);
                if (pesquisaNF.Count() == 1)
                {
                    var balancas = new BalancaCrud().PesquisarPorId(pesquisaNF[0].ID_Balancas);
                    balancas.Disponíveis = balancas.Disponíveis + pesquisaNF[0].Qt_Balanca;
                    balancas.Alugadas = balancas.Alugadas - pesquisaNF[0].Qt_Balanca;
                }
                else if (pesquisaNF.Count() > 1)
                {
                    var pesquisaBalanca = new BalancaCrud().CarregarDados();
                    for(int i = 0; i < pesquisaNF.Count(); i++)
                    {
                        var balancas = new BalancaCrud().PesquisarPorId(pesquisaNF[i].ID_Balancas);
                        balancas.Disponíveis = balancas.Disponíveis + pesquisaNF[i].Qt_Balanca;
                        balancas.Alugadas = balancas.Alugadas - pesquisaNF[i].Qt_Balanca;
                        var atualizaBalancas = new BalancaCrud().InsertOrUpdate(balancas);
                    }
                } 
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

        protected string SalvarNF(NFModel nf)
        {
            var verificaBalanca = new BalancaCrud().PesquisarPorId(nf.ID_Balancas);
            if (verificaBalanca.Disponíveis < nf.Qt_Balanca)
            {

            }
            else
            {
                verificaBalanca.Disponíveis = verificaBalanca.Disponíveis - nf.Qt_Balanca;
                verificaBalanca.Alugadas = verificaBalanca.Alugadas + nf.Qt_Balanca;
            }
            try
            {

                var insere = new NFCrud().InsertOrUpdate(nf);
                var AtualizaEstoque = new BalancaCrud().InsertOrUpdate(verificaBalanca);
                return insere;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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

        protected void gdvNF_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gdvNF_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gdvNF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            NFModel nf = new NFModel();
            if (e.CommandName == "Add")
            {
                TextBox txtQuandidade = gdvNF.Controls[0].Controls[0].FindControl("txtQuandidade") as TextBox;
                TextBox txtDtNF = gdvNF.Controls[0].Controls[0].FindControl("txtDtNF") as TextBox;
                TextBox txtValor = gdvNF.Controls[0].Controls[0].FindControl("txtValor") as TextBox;
                DropDownList ddlBalanca = gdvNF.Controls[0].Controls[0].FindControl("ddlBalanca") as DropDownList;
                nf.DataNF = Convert.ToDateTime(txtDtNF.Text);
                nf.Qt_Balanca = Convert.ToInt32(txtQuandidade.Text);
                nf.ValorNF = Convert.ToDecimal(txtValor.Text);
                nf.ID_Balancas = Convert.ToInt32(ddlBalanca.SelectedValue);
                nf.NF = Convert.ToInt32(lblTitNf.Text);
                SalvarNF(nf);
            }

            //DropDownList ddl = GridView1.Controls[0].Controls[0].FindControl("ddl") as DropDownList;
            var cliente = new EmpresaCrud();
            var objCliente = new EmpresaModel();
            var id = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case "Add":

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

                default:
                    break;
            }
        }

        protected void gdvNF_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                DropDownList ddlBalanca = (DropDownList)e.Row.FindControl("ddlBalanca");
                ddlBalanca_Bind(ddlBalanca);
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlBalancaEdit = (DropDownList)e.Row.FindControl("ddlBalancaEdit");
                    if (ddlBalancaEdit != null)
                        ddlBalanca_Bind(ddlBalancaEdit);
                }
              
            }
            else if(e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList ddlBalanca = (DropDownList)e.Row.FindControl("ddlBalanca1");
                if (ddlBalanca != null)
                    ddlBalanca_Bind(ddlBalanca);
            }
            
        }
    }
}