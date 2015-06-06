using System;
using System.Web.UI.WebControls;
using DigitalbEFF.Model;


namespace DigitalbEFF.Pages
{
    public partial class Balanca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            CarregarGrid();
        }
        public void CarregarGrid()
        {
            LimpaCampos();
            var db = new BalancaCrud();
            gridDados.DataSource = db.CarregarDados();
            gridDados.DataBind();
        }
        protected void gridDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var cliente = new BalancaCrud();
            var objeCliente = new BalancaModel();
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

                case "Visualizar":
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

            var user = new BalancaCrud();

            var objUser = user.PesquisarPorId(id);

            //txtCodigo.Text = hdn.Value;
            txtModelo.Text = objUser.Modelo;
            txtTotal.Text = objUser.Total.ToString();
            txtDisponíveis.Text = objUser.Disponíveis.ToString();
            txtAlugadas.Text = objUser.Alugadas.ToString();

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {


            var cliente = new BalancaCrud();
            var objCliente = new BalancaModel();

            objCliente.Id = hdn.Value == string.Empty ? 0 : Convert.ToInt32(hdn.Value);
            objCliente.Modelo = txtModelo.Text;
            objCliente.Total = Convert.ToInt32(txtTotal.Text);

            var cadastro = cliente.InsertOrUpdate(objCliente);

            txtResposta.Text = cadastro;
            CarregarGrid();
            ModalResposta.Show();


        }
        public void LimpaCampos()
        {
            hdn.Value = string.Empty;
            txtModelo.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtDisponíveis.Text = string.Empty;
            txtAlugadas.Text = string.Empty;
        }
    }
}