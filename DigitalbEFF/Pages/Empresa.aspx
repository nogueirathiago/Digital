<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" MasterPageFile="~/Site.Master" Inherits="DigitalbEFF.Empresa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.2.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="../Scripts/Empresa.js"></script>
    <asp:HiddenField runat="server" ID="hdn" />
    <%--<asp:FormView runat="server" ID="FormCadastro" DefaultMode="Insert" ItemType="DigitalbEFF.Model.EmpresaModel" InsertMethod="FormCadastro_InsertItem"
        CellPadding="4" ForeColor="#333333" DataKeyNames="Id">
        <InsertItemTemplate>
            Nome:<br />
            <asp:TextBox ID="NomeTextBox" runat="server" Text='<%# BindItem.Nome %>' />
            <br />
            Email:<br />
            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# BindItem.email %>' />
            <br />
            Data de Nascimento:<br />
            <asp:TextBox ID="DataNascimentoTextBox" runat="server" Text='<%# BindItem.DataNascimento %>' />
            <br />

            <asp:LinkButton ID="AdicionarButton" runat="server" CommandName="Adicionar" Text ="Adicionar"></asp:LinkButton>

            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Salvar" />
              <asp:HyperLink ID="linkModal" runat="server">HyperLink</asp:HyperLink>

            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />

            <asp:ValidationSummary runat="server" ID="validation" DisplayMode="BulletList" ShowSummary="true" ForeColor="Red" />

        </InsertItemTemplate>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

    </asp:FormView>--%>


    <asp:GridView ID="gridDados" runat="server" ItemType="DigitalbEFF.Model.EmpresaModel" SelectMethod="CarregarGrid" DataKeyNames="Id" OnRowCommand="gridDados_RowCommand">
        <Columns>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Excluir" OnClientClick="return confirm('Deseja excluir ?')" CommandArgument='<%#: Item.Id %>' Text="Excluir"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Editar" CommandArgument='<%#: Item.Id %>' Text="Editar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <div>
        <asp:HyperLink ID="linkModal" runat="server" Visible="false">HyperLink</asp:HyperLink>
        <asp:HyperLink ID="HyperLink1" runat="server">Adicionar</asp:HyperLink>
    </div>
    <asp:ModalPopupExtender ID="ModalUpdate" runat="server" TargetControlID="linkModal" PopupControlID="PainelModal">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalInsert" runat="server" TargetControlID="HyperLink1" PopupControlID="PainelModal">
    </asp:ModalPopupExtender>

    <asp:Panel ID="PainelModal" runat="server" Style="display: none" Width="750px" CssClass="modalPopup">
        <asp:Panel ID="PainelCabecalho" runat="server" Style="border-bottom: solid 1px Gray; height: 25px;">
            <div>
                <h1 style="line-height: 25px; text-align: center; font-size: 14px; font-family: Verdana; background-color: #7AC0DA;">
                    <asp:Label ID="txtTitulo" Text="Dados da Empresa" runat="server"></asp:Label>
                </h1>
            </div>
        </asp:Panel>

        <div>
            <br />
            <br />


            <table width="700px" style="margin-left: 10%;">
                <tr>
                    <td>Nome:</td>
                    <td>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" MaxLength="30" />

                        <asp:RequiredFieldValidator ID="rfvtxtNome" ControlToValidate="txtNome"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Cnpj:</td>
                    <td>
                        <asp:TextBox ID="txtCnpj" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" />
                    <asp:RequiredFieldValidator ID="rfvtxtCnpj" ControlToValidate="txtCnpj"
                        runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                        ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contato:</td>
                    <td>
                        <asp:TextBox ID="txtContato" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" MaxLength="30" />
                        <asp:RequiredFieldValidator ID="rfvtxtContato" ControlToValidate="txtContato"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Cep:</td>
                    <td>
                        <asp:TextBox ID="txtCep" runat="server" CssClass="txtEmpresa" onblur="carregaCep()" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvtxtCep" ControlToValidate="txtCep"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Endereco:</td>
                    <td>
                        <asp:TextBox ID="txtEndereco" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="rfvtxtEndereco" ControlToValidate="txtEndereco"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Municipio:</td>
                    <td>
                        <asp:TextBox ID="txtMun" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvtxtMun" ControlToValidate="txtMun"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Estado:</td>
                    <td>
                        <asp:TextBox ID="txtEstado" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvtxtEstado" ControlToValidate="txtEstado"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>
  
                    </td>
                </tr>
                <tr>
                    <td>Telefone:</td>
                    <td>
                        <asp:TextBox ID="txtTelefone" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvtxtTelefone" ControlToValidate="txtTelefone"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" MaxLength="30" />
                        <asp:RequiredFieldValidator ID="rfvtxtEmail" ControlToValidate="txtEmail"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="red"
                            ErrorMessage="*Email Invalido!" ControlToValidate="txtEmail"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Display="Dynamic">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>

            </table>


            <div style="text-align: center;">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" CausesValidation="True" ValidationGroup="Salvar" ClientIDMode="Static" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClientClick="limpaCampos()" />
            </div>



        </div>
    </asp:Panel>

</asp:Content>

