<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" MasterPageFile="~/Site.Master" Inherits="DigitalbEFF.Pages.Pedido" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.2.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="../Scripts/Pedidos.js"></script>
    <asp:HiddenField runat="server" ID="hdn" ClientIDMode="Static"/>
    <asp:HiddenField runat="server" ID="hdnFim"  ClientIDMode="Static"/>

    <div>
        <asp:TextBox ID="txtPesquisa" runat="server"></asp:TextBox>
        <asp:DropDownList runat="server" ID="ddlPesquisa" Height="30px" Width="100px" Font-Size="Medium">
            <asp:ListItem Text="Ativos" Value="1" />
            <asp:ListItem Text="Inativos" Value="2" />
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Pesquisar" OnClick="btn_Pesquisar" ClientIDMode="Static" />
    </div>

    <asp:GridView ID="gridDados" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" CssClass="cssGrid"  OnRowCommand="gridDados_RowCommand" HeaderStyle-BackColor="#7AC0DA" HeaderStyle-ForeColor="White"
        RowStyle-BackColor="#d3dce0" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000" >
        <Columns>
            <asp:BoundField HeaderText="Empresa" HeaderStyle-CssClass="cssBoundFieldHeader" DataField="Nome" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Cnpj" DataField="Cnpj"  HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Estado" DataField="Uf"  HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Contato" DataField="Contato"  HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Telefone" DataField="Telefone"  HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Email" DataField="email"  HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
              <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Finalizar" CommandArgument='<%#Eval("Id")%>' Text="Finalizar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Editar" CommandArgument='<%#Eval("Id")%>' Text="Editar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Excluir" OnClientClick="return confirm('Deseja excluir ?')" CommandArgument='<%#Eval("Id")%>' Text="Excluir"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <EmptyDataTemplate>
            Nenhum Registro Encontrado.
        </EmptyDataTemplate>
    </asp:GridView>
    <div style="margin-top: 5px">
        <asp:HyperLink ID="linkModal" runat="server" Visible="false">HyperLink</asp:HyperLink>
        <asp:HyperLink ID="HyperLink1" runat="server">Adicionar</asp:HyperLink>
    </div>
    <asp:ModalPopupExtender ID="ModalUpdate" runat="server" TargetControlID="linkModal" PopupControlID="PainelModal">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalInsert" runat="server" TargetControlID="HyperLink1" PopupControlID="PainelModal">
    </asp:ModalPopupExtender>
    <asp:ModalPopupExtender ID="ModalResposta" runat="server" TargetControlID="HyperLink1" PopupControlID="pnlResposta">
    </asp:ModalPopupExtender>



    <asp:Panel ID="pnlResposta" runat="server" Style="width: 400px; background: #7AC0DA; height: 70px;" CssClass="modalPopup">
        <div>
            <h1 style="text-align: center; font-size: 14px; font-family: Verdana; background-color: #7AC0DA;">
                <asp:Label ID="txtResposta" BackColor="#7AC0DA" runat="server"></asp:Label>
                <br />
                <asp:Button ID="Button2" runat="server" Text="OK" OnClientClick="limpaCampos()" />
            </h1>
        </div>
        <div style="text-align: center;">
        </div>
    </asp:Panel>

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
    <%--            <tr>
                    <td>Código Pedido:</td>
                    <td>
                        <asp:TextBox ID="txtCd_Pedido" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" MaxLength="30" />

                        <asp:RequiredFieldValidator ID="rfvtxtCd_Pedido" ControlToValidate="txtCd_Pedido"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>--%>
                <tr>
                    <td>NF:</td>
                    <td>
                        <asp:TextBox ID="txtNF" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvtxtNF" ControlToValidate="txtNF"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Empresa:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEmpresa" Width="412px"/>
                        <asp:RequiredFieldValidator ID="rfvtxtContato" CssClass="txtEmpresa" ControlToValidate="ddlEmpresa"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue="0"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Data de Locação:</td>
                    <td>
                        <asp:TextBox ID="txtDtLocacao" runat="server" CssClass="txtEmpresa"  ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvDtLocacao" ControlToValidate="txtDtLocacao"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Data Retorno:</td>
                    <td>
                        <asp:TextBox ID="txtDtRetorno" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" MaxLength="50" />
                        <asp:RequiredFieldValidator ID="rfvDtRetorno" ControlToValidate="txtDtRetorno" Enabled="False"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>

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

