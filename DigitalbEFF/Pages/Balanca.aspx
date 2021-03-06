﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Balanca.aspx.cs" MasterPageFile="~/Site.Master" Inherits="DigitalbEFF.Pages.Balanca" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.2.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>



<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="../Scripts/balanca.js"></script>
    <asp:HiddenField runat="server" ID="hdn" ClientIDMode="Static" />

    <asp:GridView ID="gridDados" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" CssClass="cssGrid" OnRowCommand="gridDados_RowCommand" HeaderStyle-BackColor="#7AC0DA" HeaderStyle-ForeColor="White"
        RowStyle-BackColor="#d3dce0" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000">
        <Columns>
            <asp:BoundField HeaderText="Modelo" HeaderStyle-CssClass="cssBoundFieldHeader" DataField="Modelo" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Total" DataField="Total" HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Alugadas" DataField="Alugadas" HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Disponíveis" DataField="Disponíveis" HeaderStyle-CssClass="cssBoundFieldHeader" ItemStyle-CssClass="cssBoundField"
                ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="btnVisualizar" runat="server" CausesValidation="False" CommandName="Visualizar" CommandArgument='<%#Eval("Id")%>' Text="Visualizar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Excluir" OnClientClick="return confirm('Deseja excluir ?')" CommandArgument='<%#Eval("Id")%>' Text="Excluir"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Editar" CommandArgument='<%#Eval("Id")%>' Text="Editar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" onClientClick="limpaCampos()">Adicionar</asp:HyperLink>
    </div>

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
                    <asp:Label ID="txtTitulo" Text="Dados da Balança" runat="server"></asp:Label>
                </h1>
            </div>
        </asp:Panel>
        <div>
            <br />
            <br />
            <table style="width: 700px; margin-left: 10%;">
   <%--             <tr>
                    <td>Código:</td>
                    <td>
                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="txtEmpresa" ReadOnly="true" ClientIDMode="Static" MaxLength="30" />
                    </td>
                </tr>--%>
                <tr>
                    <td>Modelo:</td>
                    <td>
                        <asp:TextBox ID="txtModelo" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="rfvtxtModelo" ControlToValidate="txtModelo"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Total:</td>
                    <td>
                        <asp:TextBox ID="txtTotal" runat="server" CssClass="txtEmpresa" ClientIDMode="Static" MaxLength="30" />
                        <asp:RequiredFieldValidator ID="rfvtxtTotal" ControlToValidate="txtTotal"
                            runat="server" ErrorMessage="*Campo Obrigatório" SetFocusOnError="true" Display="Static" ForeColor="Red"
                            ValidationGroup="Salvar" InitialValue=""></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Alugadas:</td>
                    <td>
                        <asp:TextBox ID="txtAlugadas" runat="server" CssClass="txtEmpresa" ReadOnly="true" ClientIDMode="Static" />
                    </td>
                </tr>
                <tr>
                    <td>Disponíveis:</td>
                    <td>
                        <asp:TextBox ID="txtDisponíveis" runat="server" CssClass="txtEmpresa" ReadOnly="true" ClientIDMode="Static" MaxLength="50" />
                    </td>
                </tr>

            </table>


            <div style="text-align: center;">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" CausesValidation="True" ValidationGroup="Salvar" ClientIDMode="Static" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClientClick="limpaCampos()"/>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

